using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointPowerScript : MonoBehaviour
{
    // Special references
    [SerializeField] private GameObject holder;
    [SerializeField] private GameObject platform;
    [SerializeField] private AudioSource sfx;

    // Some variables
    private SpriteRenderer hSprite;
    private SpringJoint2D platformSJ;
    private bool isBroken = false;
    private Rigidbody2D rBody;

    // Public ones
    public Sprite brokenSprite;

    void Start()
    {
        hSprite = holder.GetComponent<SpriteRenderer>();
        platformSJ = platform.GetComponent<SpringJoint2D>();
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
