using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private float FixedYValue = 5.5f;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerTransform != null)
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + FixedYValue, transform.position.z);
    }
}
