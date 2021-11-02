using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    // Special references
    [SerializeField] SliderJointPowerScript sliderPower;
    [SerializeField] AudioClip grabPowerSFX;
    [SerializeField] AudioClip usePowerSFX;
    [SerializeField] AudioSource sfx;

    // Tweakable variables
    public float sliderPowerYoffset = 3f;

    // Some variables
    public string currentPowerString = "None";
    private int currentPower = 0;

    public void GrabPower(int whatPower)
    {
        currentPower = whatPower;

        switch (whatPower)
        {
            case 0:
                currentPowerString = "None";
                break;
            case 1:
                currentPowerString = "SliderJoint";
                break;
            case 2:
                currentPowerString = "SprintJoint";
                break;
            case 3:
                currentPowerString = "TargetJoint";
                break;
            case 4:
                currentPowerString = "WheelJoint";
                break;
            case 5:
                currentPowerString = "RelativeJoint";
                break;
            case 6:
                currentPowerString = "HingeJoint";
                break;
            case 7:
                currentPowerString = "FrictionJoint";
                break;
            case 8:
                currentPowerString = "FixedJoint";
                break;
            case 9:
                currentPowerString = "DistanceJoint";
                break;
        }

        sfx.clip = grabPowerSFX;
        sfx.Play();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && currentPower != 0)
        {
            switch (currentPower)
            {
                case 1:
                    Instantiate(sliderPower, new Vector2(transform.position.x, transform.position.y + sliderPowerYoffset), new Quaternion());
                    break;
            }

            sfx.clip = usePowerSFX;
            sfx.Play();
            currentPower = 0;
        }
    }
}
