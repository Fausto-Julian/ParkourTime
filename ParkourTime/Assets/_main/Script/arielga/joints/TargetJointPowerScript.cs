using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetJointPowerScript : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnJointBreak2D(Joint2D joint)
    {
        rBody.constraints = RigidbodyConstraints2D.None;
        sfx.Play();
    }
}
