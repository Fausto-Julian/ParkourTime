using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderItem : MonoBehaviour
{
    [SerializeField] private bool isBadPower = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowers pPowers = collision.GetComponent<PlayerPowers>();
            if (isBadPower)
            {
                pPowers.GrabPower(10);
            }
            else
                pPowers.GrabPower(1);

            Destroy(gameObject);
        }
    }
}
