using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    public GameObject particleSystemPrefab;
    public float radius;
    public float explosionDelay;

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(DelayedExplosion());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Firebolt")) //bomb explodes twice as potent if shot
        {
            Explode(radius*2);
            gameObject.SetActive(false);
        }
    }
    private IEnumerator DelayedExplosion()
    {
        yield return new WaitForSeconds(explosionDelay);
        Explode(radius);
        gameObject.SetActive(false);
    }

    void Explode(float range)
    {
        var particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
        Destroy(particleSystemInstance, 3f); //Destroys the particle system after 3 seconds

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range); //creates the bomb hitbox and puts them in an array
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                var playerdamaged = hitCollider.GetComponent<DamageReceiver>();
                if (playerdamaged != null)
                {
                    playerdamaged.ApplyDamage(damage);
                    GameData.PlayerHealth -= (int)damage;
                }
            }
            else if (hitCollider.CompareTag("Enemy"))
            {
                var enemydamaged = hitCollider.GetComponent<Enemy>();
                if (enemydamaged != null)
                {
                    enemydamaged.ApplyDamage(damage);
                }
            }
        }
    }


}