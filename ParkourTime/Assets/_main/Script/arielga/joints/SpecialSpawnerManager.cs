using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class SpecialSpawnerManager : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 1f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<GameObject> objectsPrefabs;
    [SerializeField] private List<Transform> spawnsPoints;

    [SerializeField, Range(1f, 10f)] private float randomTimer = 1f;
    [SerializeField, Range(1f, 3f)] private float randomMultiplierRange = 1f;
    private float t;

    [SerializeField] private AudioSource sfx;

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
            float theRandTimer = Random.Range(randomTimer, randomTimer * randomMultiplierRange);
            t = 0 - theRandTimer;
            Debug.Log($"{t} & {theRandTimer}");
            // Joints update added stuff:
            sfx.Play();
        }
    }
}
