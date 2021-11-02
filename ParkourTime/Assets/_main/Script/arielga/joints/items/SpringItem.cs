using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowers pPowers = collision.GetComponent<PlayerPowers>();
            pPowers.GrabPower(2);
            Destroy(gameObject);
        }
    }
}
