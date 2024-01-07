using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    protected Rigidbody2D rb;
    protected float xpseed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    protected virtual void OnEnable()
    {
        Vector2 myforce = transform.up * speed;
        rb.AddForce(myforce, ForceMode2D.Impulse);
    }

} 