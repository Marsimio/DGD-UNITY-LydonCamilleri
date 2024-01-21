using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageReceiver : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void ApplyDamage(int damage)
    {
        GameData.PlayerHealth -= damage;
        GameManager.Instance.PlayerDamage();
        spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }
}