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

    // Public ones
    public Sprite brokenSprite;

    // Start is called before the first frame update
    void Start()
    {
        hSprite = holder.GetComponent<SpriteRenderer>();
        platformSJ = platform.GetComponent<SpringJoint2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (platformSJ == null && !isBroken)
        {
            isBroken = true;
            hSprite.sprite = brokenSprite;
            sfx.Play();
        }
    }
}
