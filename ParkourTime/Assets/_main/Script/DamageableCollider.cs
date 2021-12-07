using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCollider : MonoBehaviour
{
    public int temp;
    public int damage;
    public Rigidbody2D rb;
    public bool temp2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            var damageable = collision.gameObject.GetComponent<HealthController>();

            if (damageable != null && rb.velocity.y <= -temp && temp2 == false) 
            {
                temp2 = true;
                print("me hizo daño");
                damageable.TakeDamage(damage);

            }
        }
    }
}
