using System;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public Action OnWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnWin?.Invoke();
        }
    }
}
