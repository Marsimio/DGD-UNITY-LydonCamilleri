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
        if (GameData.PlayerHealth > 0)
        {
            GameData.PlayerHealth -= damage;
            spriteRenderer.color = Color.red;
            StartCoroutine(ResetColor());
        }
        GameManager.Instance.PlayerDamage();
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }
}