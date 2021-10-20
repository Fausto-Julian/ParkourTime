using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Special references
    [SerializeField] private SimpleRandomBlock blockPrefab;
    [SerializeField] private SimpleRandomBlock circlePrefab;
    [SerializeField] PlayerScript player;

    // Tweakable variables
    [Range(1f, 100f)] public float spawnTimer = 1f;
    public float currentSpawnTimer = 0f;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;

    // Some variables
    private SimpleRandomBlock randType;
    private float t;

    private void Start()
    {
        randType = blockPrefab;
    }
    private void Update()
    {
        transform.position = new Vector3(-2.83f, player.transform.position.y + 12f, 0f);
        t = Time.deltaTime;
    } 

    void FixedUpdate()
    {
        if(currentSpawnTimer <= 0)
        {
            Spawn(Random.Range(-1, 4));
            currentSpawnTimer = spawnTimer + Random.Range(0f, 2f);
        }
        else
        {
            currentSpawnTimer -= t;
        }
    }

    private void Spawn(int slotSelector)
    {
        // Generate a block or a circle
        float blockType = Random.Range(0f, 1f);
        if (blockType > 0.3f)
        {
            randType = blockPrefab;
        }
        else
        {
            randType = circlePrefab;
        }

        // Spawn
        switch (slotSelector)
        {
            case 0:
                Instantiate(randType, new Vector3(spawnPoint1.transform.position.x, spawnPoint1.transform.position.y, 0f), new Quaternion());
                break;

            case 1:
                Instantiate(randType, new Vector3(spawnPoint2.transform.position.x, spawnPoint2.transform.position.y, 0f), new Quaternion());
                break;

            case 2:
                Instantiate(randType, new Vector3(spawnPoint3.transform.position.x, spawnPoint3.transform.position.y, 0f), new Quaternion());
                break;

            case 3:
                Instantiate(randType, new Vector3(spawnPoint4.transform.position.x, spawnPoint4.transform.position.y, 0f), new Quaternion());
                break;

            case 4:
                Instantiate(randType, new Vector3(spawnPoint5.transform.position.x, spawnPoint5.transform.position.y, 0f), new Quaternion());
                break;

        }
    }
}
