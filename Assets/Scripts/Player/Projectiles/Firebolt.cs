using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : Projectile
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Wall hit");
        if (collision.gameObject.CompareTag("Walls") || (collision.gameObject.CompareTag("Bomb")))
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemydamaged = collision.gameObject.GetComponent<Enemy>();
            if (enemydamaged != null)
            {
                enemydamaged.ApplyDamage(damage); //damages enemy
                gameObject.SetActive(false);
            }

        }
    }
}
