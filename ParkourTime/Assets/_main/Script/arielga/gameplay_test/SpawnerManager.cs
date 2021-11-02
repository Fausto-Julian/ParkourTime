using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<GameObject> objectsPrefabs;
    [SerializeField] private List<Transform> spawnsPoints;
    [SerializeField, Range(0.1f, 1f)] private float spawnTimerDifficulty = 0.15f;
    private float t;

    // Joints update added stuff:
    [SerializeField] private SpawnerSFX sfx;


    private void Update()
    {
        t += Time.deltaTime;

        if (playerTransform != null)
            transform.position = new Vector3(0f, playerTransform.position.y + 12f, 0f);

        if (t >= spawnTimer)
        {
            var indexSpawn = Random.Range(0, spawnsPoints.Count);
            var indexObject = Random.Range(0, objectsPrefabs.Count);
            Instantiate(objectsPrefabs[indexObject], spawnsPoints[indexSpawn].position, spawnsPoints[indexSpawn].rotation);
            t = 0;

            // Joints update added stuff:
            sfx.PlaySFX();
        }
    }

    public void UpdateDifficulty()
    {
        spawnTimer -= spawnTimerDifficulty;
        Debug.Log($"Difficulty updated, new times = NormalSpawnTimer {spawnTimer}");
    }
}
