using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    // Special references
    [SerializeField] SliderJointPowerScript sliderPowerGood;
    [SerializeField] SliderJointPowerScript sliderPowerBad;
    [SerializeField] SpringJointPowerScript springPowerGood;
    [SerializeField] SpringJointPowerScript springPowerBad;
    [SerializeField] TargetJointPowerScript targetPowerGood;
    [SerializeField] TargetJointPowerScript targetPowerBad;
    [SerializeField] AudioClip grabPowerSFX;
    [SerializeField] AudioClip usePowerSFX;
    [SerializeField] AudioSource sfx;

    // Tweakable variables
    public float sliderPowerYoffset = 3f;
    public float springPowerYoffset = 3f;
    public float targetPowerYoffset = 3f;

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
                currentPowerString = "SpringJoint";
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
            case 10:
                currentPowerString = "SliderJointBad";
                break;
            case 11:
                currentPowerString = "SpringJointBad";
                break;
            case 12:
                currentPowerString = "TargetJointBad";
                break;
            case 13:
                currentPowerString = "WheelJointBad";
                break;
            case 14:
                currentPowerString = "RelativeJointBad";
                break;
            case 15:
                currentPowerString = "HingeJointBad";
                break;
            case 16:
                currentPowerString = "FrictionJointBad";
                break;
            case 17:
                currentPowerString = "FixedJointBad";
                break;
            case 18:
                currentPowerString = "DistanceJointBad";
                break;
        }

        sfx.clip = grabPowerSFX;
        sfx.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentPower != 0)
        {
            switch (currentPower)
            {
                // Good spawns
                case 1:
                    Instantiate(sliderPowerGood, new Vector2(transform.position.x, transform.position.y + sliderPowerYoffset), new Quaternion());
                    break;

                case 2:
                    Instantiate(springPowerGood, new Vector2(transform.position.x, transform.position.y + springPowerYoffset), new Quaternion());
                    break;

                case 3:
                    Instantiate(targetPowerGood, new Vector2(transform.position.x, transform.position.y + targetPowerYoffset), new Quaternion());
                    break;

                // Bad spawns
                case 10:
                    Instantiate(sliderPowerBad, new Vector2(transform.position.x, transform.position.y + sliderPowerYoffset), new Quaternion());
                    break;

                case 11:
                    Instantiate(springPowerBad, new Vector2(transform.position.x, transform.position.y + springPowerYoffset), new Quaternion());
                    break;

                case 12:
                    Instantiate(targetPowerBad, new Vector2(transform.position.x, transform.position.y + targetPowerYoffset), new Quaternion());
                    break;
            }

            sfx.clip = usePowerSFX;
            currentPowerString = "None";
            sfx.Play();
            currentPower = 0;
        }
    }
}
