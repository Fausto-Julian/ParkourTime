using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSFX : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    public void PlaySFX()
    {
        sfx.Play();
    }
}
