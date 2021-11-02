using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointsConnectionShow : MonoBehaviour
{
    public Transform connector1;
    public Transform connector2;

    private void Update()
    {
        Debug.DrawLine(connector1.position, connector2.position, Color.cyan);
    }
}
