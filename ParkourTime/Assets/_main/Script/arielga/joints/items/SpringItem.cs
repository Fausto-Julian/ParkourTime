using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringItem : MonoBehaviour
{
    [SerializeField] private bool isBadPower = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowers pPowers = collision.GetComponent<PlayerPowers>();
            if (isBadPower)
            {
                pPowers.GrabPower(11);
            }
            else
                pPowers.GrabPower(2);
            Destroy(gameObject);
        }
    }
}
