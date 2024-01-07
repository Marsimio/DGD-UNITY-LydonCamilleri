using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int start_hitpoints;
    public int start_strength;
    public float start_speed;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void ApplyDamage(float damage)
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
        start_hitpoints -= (int)damage;
        if (start_hitpoints <= 0) 
        {
            Destroy(gameObject);
        }

    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }
}