public class Undead : MonoBehaviour, IProperty
{
    public Human Human;
    public Castle Castle;
    public int Health = 100;
    public bool _isAttack;
    private int _powerAttack;
    private float _timeAttack;
    public bool _isArcher;
    private float _speed;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    public Enemes TypeEnemes;
    public Slider HealthBar;
    public Canvas canvas;
    public void Attack()
    {
        _isAttack = true;
        if (Human.Health > 0)
        {
            _animator.Play("Attack");
            StartCoroutine(TamiDamage());
        }
        else
        {
            _isAttack = false;
        }
    }
    private void CastleAttack()
    {
        _isAttack = true;
        if (Castle.Health > 0)
        {
            _animator.Play("Attack");
            StartCoroutine(CastleTamiDamage());
        }
        else
        {
            _isAttack = false;
        }
    }
    public void Move(float speed)
    {
        if (_isAttack == false)
        {
            _animator.Play("Move");
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }
    }
    IEnumerator TamiDamage()
    {
        yield return new WaitForSeconds(_timeAttack);
        if (Human != null)
        {
            Human.TakeDamage(_powerAttack);
            Attack();
        }
    }
    IEnumerator CastleTamiDamage()
    {
        yield return new WaitForSeconds(_timeAttack);
        if (Castle != null)
        {
            Castle.TakeDamage(_powerAttack);
            CastleAttack();
        }
    }

    public void TakeDamage(int damage)
    {

        GetComponent<Renderer>().material.color = Color.red;
        Health -= damage;
        Invoke("ColorEnemies", 0.3f);
    }
    private void ColorEnemies()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        switch (TypeEnemes)
        {
            case Enemes.skelet:
                _isAttack = false;
                _speed = -2;
                _powerAttack = 2;
                _timeAttack = 1;
                Health = 10;
                break;
            case Enemes.gost:
                _isAttack = false;
                _speed = -2;
                _powerAttack = 5;
                _timeAttack = 1.4f;
                Health = 20;
                break;
            case Enemes.vampire:
                break;
            default:
                break;
        }

    }
    public enum Enemes
    {
        skelet,
        gost,
        vampire
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Human")
        {
            var Player1 = collision.gameObject;
            Human = Player1.GetComponent<Human>();
            if (_isAttack == false)
            {
                Attack();
            }
        }
        if (collision.gameObject.tag == "Castle")
        {
            var Player2 = collision.gameObject;
            Castle = Player2.GetComponent<Castle>();
            Castle.TakeDamage(_powerAttack);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Human == null)
        {
            _isAttack = false;
            Move(_speed);
        }
        Move(_speed);
    }
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
