using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDifficulty : MonoBehaviour
{
    public bool activated = false;
    public GameObject theCollider;
    public GameObject lvlDiffObject;
    public Color deactivatedColor = new Color(0f, 0f, 0f, 255f);
    public Color activatedColor = new Color(255, 255, 255, 255);

    private SpriteRenderer spr;
    private towerDifficulty difficultyScript;

    private void Start()
    {
        difficultyScript = lvlDiffObject.GetComponent<towerDifficulty>();
        theCollider.gameObject.SetActive(false);
        spr = GetComponent<SpriteRenderer>();
        spr.color = deactivatedColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            activated = true;
            theCollider.gameObject.SetActive(true);
            difficultyScript.UpdateDifficulty();
            spr.color = activatedColor;
        }

    }
}
