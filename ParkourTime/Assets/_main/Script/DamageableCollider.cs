using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCollider : MonoBehaviour
{
    [SerializeField] private int temp;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private bool temp2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("CabezaPlayer"))
        {
            var damageable = collision.gameObject.transform.parent.GetComponent<HealthController>();

            if (damageable != null && rb.velocity.y <= -temp && temp2 == false)
            {
                temp2 = true;
                print("me hizo daño");
                damageable.TakeDamage(damage);

            }
        }
    }
}
