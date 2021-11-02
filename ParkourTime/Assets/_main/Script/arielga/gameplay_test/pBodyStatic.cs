using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBodyStatic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Rigidbody2D rBody = collision.GetComponent<Rigidbody2D>();
        if (!collision.CompareTag("Walls") && rBody.bodyType != RigidbodyType2D.Static)
        {
            //rBody.bodyType = RigidbodyType2D.Static;
            Destroy(collision);
            Debug.Log($"Rigidbody ({rBody}) has been destroyed.");
        }

    }
}
