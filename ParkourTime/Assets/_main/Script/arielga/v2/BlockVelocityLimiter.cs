using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class BlockVelocityLimiter : MonoBehaviour
{
    public float maxRandomVelocityModifier = 6f;
    public float maxRandomMassModifier = 10f;
    public float maxRandomGravityScaleModifier = 0.5f;
    public float maxXscaleModifier = 2f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        maxRandomVelocityModifier += Random.Range(-maxRandomVelocityModifier, maxRandomVelocityModifier);
        body = GetComponent<Rigidbody2D>();
        body.mass += Random.Range(-maxRandomMassModifier, maxRandomMassModifier);
        body.gravityScale += Random.Range(-maxRandomGravityScaleModifier, maxRandomGravityScaleModifier);
        transform.localScale = new Vector3(Random.Range(-maxXscaleModifier, maxXscaleModifier), 1f , 1f);
        float canRotate = Random.Range(0f, 2f);

        if (canRotate > 1.9f)
        {

        }
        body.freezeRotation = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.y < -maxRandomVelocityModifier)
        {
            body.velocity = new Vector2(body.velocity.x, -maxRandomVelocityModifier);
        }
    }
}
