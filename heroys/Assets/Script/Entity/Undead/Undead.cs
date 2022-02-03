using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public abstract class Undead : MonoBehaviour
{
    protected abstract void Move(Vector2 vector, float speed);
    public abstract void TakeDamage(int damage); 
    protected virtual void RedColorEnemies(SpriteRenderer spriteRenderer, Color color)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = color;
    }

}
