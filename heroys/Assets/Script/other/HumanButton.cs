using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public abstract class HumanButton : MonoBehaviour
{
    [SerializeField] protected int _price;
    [SerializeField] protected float _timeDelay;
    [SerializeField] protected KeyCode _buttonSpawn;
    private bool _isdelay = true;
    [SerializeField] protected SpawnPoint _spawnPoint;
    protected AudioSource _audioSource;
    protected bool IsDelay()
    {
        return _isdelay;
    }
    protected void Delay(Image image)
    {
        _isdelay = false;
        StartCoroutine(Wait(image));
    }
    protected Image ColorImage(Image image, Color color)
    {
        image.color = color;
        return image;
    }
    private IEnumerator Wait(Image image)
    {
        yield return new WaitForSeconds(_timeDelay);
        _isdelay = true;
        ColorImage(image, Color.white);
    }
    public virtual int GetPrice()
    {
        return _price;
    }
}
