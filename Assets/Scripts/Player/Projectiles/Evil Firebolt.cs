using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EvilFirebolt : Projectile
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<DamageReceiver>();
            if (player != null)
            {
                player.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
