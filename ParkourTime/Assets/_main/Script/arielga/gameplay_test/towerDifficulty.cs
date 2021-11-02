using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDifficulty : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject theGameManager;
    public float trumpAmount = 2f;

    private float t = 0f;
    private float totalTrumpAmount = 2f;
    private bool isMovingTheWalls = false;
    private float originalLeftX = 0f;
    private SpecialSpawnerManager ssmScript;
    private SpawnerManager smScript;

    private void Start()
    {
        ssmScript = theGameManager.GetComponent<SpecialSpawnerManager>();
        smScript = theGameManager.GetComponent<SpawnerManager>();
    }

    private void Update()
    {
        t = Time.deltaTime;
        if (isMovingTheWalls)
            BuildTheWall();
    }

    public void UpdateDifficulty()
    {
        sfx.Play();
        totalTrumpAmount += trumpAmount;
        isMovingTheWalls = true;
        originalLeftX = leftWall.transform.position.x;
        ssmScript.UpdateDifficulty();
        smScript.UpdateDifficulty();
    }

    private void BuildTheWall()
    {
        if (leftWall.transform.position.x < originalLeftX + totalTrumpAmount)
        {
            leftWall.transform.position = new Vector2(leftWall.transform.position.x + t, leftWall.transform.position.y);
            rightWall.transform.position = new Vector2(rightWall.transform.position.x - t, rightWall.transform.position.y);
        }
        else
            isMovingTheWalls = false;
    }
}
