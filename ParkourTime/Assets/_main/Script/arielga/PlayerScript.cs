using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Tweakable variables
    [Range(1f, 25f)] public float speed = 10f;
    [Range(1f, 30f)] public float maxSpeed = 25f;
    [Range(0.11f, 500f)] public float jumpForce = 120f;
    //[Range(0.1f, 2f)] public float jumpTime = 0.2f;
    [Range(10f, 1000f)] public float forcedGravity = 1f;
    public GameObject feets;

    // Some variables
    Rigidbody2D rbody;
    Collider2D theCollider;
    Vector2 input;
    float t;
    public float jumpTimer = 0;
    public bool isCallingJump = false;
    public bool isAlreadyJumping = false;
    private float ogFG = 0f;

    public float testX = 0f;
    public float testY = 0f;

    public LayerMask theLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        theCollider = GetComponent<Collider2D>();
        ogFG = forcedGravity;
    }

    private void Update()
    {
        t = Time.deltaTime;
        if (forcedGravity != 0)
        {
            input = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), 0f), 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            forcedGravity = 0;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            forcedGravity = ogFG;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Forced gravity
        rbody.AddForce(Vector3.down * forcedGravity, ForceMode2D.Force);

        Vector2 desiredSpeed = input * speed;
        Vector2 speedDifference = desiredSpeed - rbody.velocity;
        Vector2 forceDirection = speedDifference.normalized;
        float forceNeeded = speedDifference.magnitude * rbody.mass;
        float force = Mathf.Clamp(forceNeeded, 0f, maxSpeed);

        // Left/Right movement
        rbody.AddForce(force * forceDirection, ForceMode2D.Impulse);

    }

    private void Jump()
    {
        Collider2D colliderFeets = Physics2D.OverlapBox(feets.transform.position, new Vector2(testX, testY), 0f, theLayerMask);
        print(colliderFeets.gameObject.name);

        if (colliderFeets != null)
        {
            rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}
