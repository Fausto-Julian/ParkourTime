using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class surface : MonoBehaviour
{
    private SurfaceEffector2D effector;
    void Start()
    {
        effector = GetComponent<SurfaceEffector2D>();
        effector.speed = Random.Range(-3.5f, 3.5f);
    }
}
