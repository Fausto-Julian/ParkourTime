using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoyancy : MonoBehaviour
{
    private BuoyancyEffector2D effector;
    public float multiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<BuoyancyEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        effector.flowAngle = transform.rotation.z * multiplier;
    }
}
