using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class SimpleRandomBlock : MonoBehaviour
{
    // Tweakable variables
    [Range(1f, 10f)] public float maxSizeX = 3f;
    [Range(1f, 10f)] public float maxSizeY = 3f;
    [Range(0.1f, 1f)] public float minMass = 1f;
    [Range(1f, 50f)] public float maxMass = 50f;

    public Color lightColor = new Color(0, 255f, 0, 255f);
    public Color mediumColor = new Color(255f, 255f, 0, 255f);
    public Color heavyColor = new Color(255f, 0, 0, 255f);
    public Color reallyHeavyColor = new Color(0, 0, 0, 255f);

    public float lightValue = 10f;
    public float mediumValue = 25f;
    public float heavyValue = 35f;
    public float reallyHeavyValue = 45f;

    // Special references
    SpriteRenderer spr;
    Transform theObject;
    Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        int form = Random.Range(0, 1);
        bool isBlock = true;
        if (form == 1)
        {
            isBlock = false;
        }


        // Get components...
        rBody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        theObject = GetComponent<Transform>();

        rBody.mass = Random.Range(minMass, maxMass);

        // Set stuff
        if (!isBlock)
        {
            float randCircleSize = Random.Range(0.5f, maxSizeX);
            theObject.localScale = new Vector3(randCircleSize, randCircleSize, 0f);
            rBody.gravityScale = rBody.mass * (theObject.localScale.x *2);
        }
        else
        {
            theObject.localScale = new Vector3(Random.Range(0.5f, maxSizeX), Random.Range(0.5f, maxSizeY), 0f);
            rBody.gravityScale = rBody.mass * (theObject.localScale.x + theObject.localScale.y);
        }



        if (rBody.mass < lightValue)
        {
            spr.color = lightColor;
        }
        else if (rBody.mass < mediumValue)
        {
            spr.color = mediumColor;
        }
        else if (rBody.mass < heavyValue)
        {
            spr.color = heavyColor;
        }
        else if (rBody.mass > heavyValue)
        {
            spr.color = reallyHeavyColor;
        }



    }
}
