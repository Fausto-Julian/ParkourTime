using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioClip lowJumpSFX;
    [SerializeField] AudioClip highJumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip itemSFX;

    public AudioClip deathSFX;
    public AudioSource audioSource;
    
    public void JumpLowSFX()
    {
        audioSource.clip = lowJumpSFX;
        audioSource.Play();
    }

    public void JumpHighSFX()
    {
        audioSource.clip = highJumpSFX;
        audioSource.Play();
    }

    public void LandSFX()
    {
        audioSource.clip = landSFX;
        audioSource.Play();
    }

    public void ItemSFX()
    {
        audioSource.clip = itemSFX;
        audioSource.Play();
    }

    public void DeathSFX()
    {
        audioSource.clip = deathSFX;
        audioSource.Play();
    }
}
