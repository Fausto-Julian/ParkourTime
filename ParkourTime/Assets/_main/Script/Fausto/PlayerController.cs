using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float aceleracionMax;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpForceTwo;
    [SerializeField] private LayerMask killPlayerMask;
    [SerializeField] private LayerMask jumpMask;

    [SerializeField] private PlayerSFX sfx;
    [SerializeField] private float forceMovement;
    //private float movement;
    private Rigidbody2D rBody;
    private bool jumpTwo;
    private HealthController healthController;



    // Joints update added stuff:

    [SerializeField] private PlayerAnimationsManager animScript;
    [SerializeField] private GameObject animObject;
    private SpriteRenderer sprRef;
    // * WIP * when the player steps on the floor after a fall. 
    // private bool alreadyLanded = false; 



    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        healthController = GetComponent<HealthController>();
        sprRef = animObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //movement = Input.GetAxisRaw("Horizontal");



        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Compruebo que el player este en el piso/bloque
            Collider2D colliderJump = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 1), new Vector2(0.5f, 0.2f), 0f, jumpMask);

            // Si esta aplica un fueza hacia arriba y activa el 2do salto
            if (colliderJump != null)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpTwo = true;

                // Joints update added stuff:
                sfx.JumpLowSFX();
            }
            else if (jumpTwo)
            {
                rBody.AddForce(Vector2.up * jumpForceTwo, ForceMode2D.Impulse);
                jumpTwo = false;

                // Joints update added stuff:
                sfx.JumpHighSFX();
            }

        }

        // Compruebo si un objeto le cayo arriba del personaje, si se le cae a la cabeza muere

    }

    private void FixedUpdate()
    {
        // Movimiento del player

        float speedDesired = Input.GetAxisRaw("Horizontal") * aceleracionMax;
        float speedDifference = speedDesired - rBody.velocity.x;
        float forceX = Mathf.Clamp(speedDifference * forceMovement, -aceleracionMax, aceleracionMax);
        rBody.AddForce(Vector2.right * forceX);

        // Joints update added stuff
        float animSpeed = speedDesired;
        if (speedDesired < 0)
        {
            sprRef.flipX = true;
            animSpeed = -animSpeed;
        }
        else if (speedDesired > 0)
        {
            sprRef.flipX = false;
        }
        animScript.UpdateSpeed(animSpeed);
        // Joints update added stuff

    }

   
}
