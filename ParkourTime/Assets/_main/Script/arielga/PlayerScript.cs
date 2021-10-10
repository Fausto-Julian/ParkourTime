using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Tweakable variables
    [Range(1f, 25f)] public float speed = 10f;
    [Range(1f, 30f)] public float maxSpeed = 25f;
    [Range(0.11f, 2f)] public float jumpForce = 0.2f;
    [Range(0.1f, 0.5f)] public float jumpTime = 0.2f;
    [Range(10f, 1000f)] public float forcedGravity = 1f;

    // Some variables
    Rigidbody2D rbody;
    Collider2D theCollider;
    Vector2 input;
    float t;
    public float jumpTimer = 0;
    public bool isCallingJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        theCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        t = Time.deltaTime;
        input = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), 0f), 1f);
        IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && !isCallingJump)
        {
            isCallingJump = true;
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

        if (isCallingJump)
        {
            CallJump();
        }
        Jump();
    }

    private void IsGrounded()
    {

    }

    private void CallJump()
    {
        if (jumpTimer <= 0)
        {
            jumpTimer = jumpTime;
            isCallingJump = false;
        }
    }

    private void Jump()
    {
        if (jumpTimer > 0 && rbody.velocity.y < 20)
        {
            jumpTimer -= t;
            rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Jump();
        }
    }

}
