using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    GameObject player;
    public float yRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pPos = new Vector3 (-2.36f, player.transform.position.y + 2f, -25f);
        /*
        if (Input.GetKey(KeyCode.E) && yRot > -5)
        {
            yRot -= 0.1f;
        }
        if (Input.GetKey(KeyCode.Q) && yRot < 5)
        {
            yRot += 0.1f;
        }
        */
        transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        transform.position = pPos;
    }
}
