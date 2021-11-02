using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float parallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCamPos;
    private float height;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;
        height = GetComponent<SpriteRenderer>().size.y;

    }

    private void Update()
    {
        var cameraDelta = cameraTransform.position.y - lastCamPos.y;

        transform.position += new Vector3(0, cameraDelta * parallaxMultiplier, 0);

        lastCamPos = cameraTransform.position;

        var distanceToCamera = cameraTransform.position.y - transform.position.y;

        if (Mathf.Abs(distanceToCamera) >= height)
        {
            if (distanceToCamera > 0) {

                transform.position += new Vector3(0, height * 2, 0);
            }
            else
            {
                transform.position += new Vector3(0, height * -2, 0);
            }
        }
        
    }

}
