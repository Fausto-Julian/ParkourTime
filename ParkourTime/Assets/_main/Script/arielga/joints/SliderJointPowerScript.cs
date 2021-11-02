using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderJointPowerScript : MonoBehaviour
{
    // Special references
    [SerializeField] private GameObject holder;
    [SerializeField] private GameObject platform;
    [SerializeField] private AudioSource sfx;

    // Some variables
    private SpriteRenderer hSprite;
    private SliderJoint2D platformSJ;
    private Rigidbody2D rBody;
    private bool isBroken = false;

    // Public ones
    public Sprite brokenSprite;

    void Start()
    {
        hSprite = holder.GetComponent<SpriteRenderer>();
        platformSJ = platform.GetComponent<SliderJoint2D>();
        rBody = platform.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (platformSJ == null && !isBroken)
        {
            rBody.constraints = RigidbodyConstraints2D.None;
            isBroken = true;
            hSprite.sprite = brokenSprite;
            sfx.Play();
        }
    }
}
