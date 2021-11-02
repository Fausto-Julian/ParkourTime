using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    [SerializeField] private GameObject sprObject;
    private Animator animaThor;

    private void Start()
    {
        animaThor = sprObject.GetComponent<Animator>();
    }

    public void UpdateSpeed(float input)
    {
        animaThor.SetFloat("Speed", input);
    }
}
