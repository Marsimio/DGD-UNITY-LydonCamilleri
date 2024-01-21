using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public int start_hitpoints;
    public int start_strength;
    public float start_firerate;
    public GameObject start_projectile;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine fireCoroutine;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");

        originalColor = spriteRenderer.color;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {

        }
    }

    public void ApplyDamage(float damage)
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
        start_hitpoints -= (int)damage;
        if (start_hitpoints <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.EnemyDefeated();
        }
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }

    private void OnBecameVisible()
    {
        fireCoroutine = StartCoroutine(FireProjectile());
    }
    private void OnBecameInvisible()
    {
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireProjectile()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(start_firerate);
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(start_projectile, transform.position, Quaternion.identity);

        Vector3 direction = (player.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 10f;
    }
}