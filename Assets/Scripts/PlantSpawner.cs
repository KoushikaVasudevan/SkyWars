using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] clouds;

    [SerializeField] private float spawnXPos;
    [SerializeField] private float plantSpawnYPos;
    [SerializeField] private float cloudYPos;

    [SerializeField] private float timeBetweenSpawns;

    private void Start()
    {
        StartCoroutine(spawnBackground(timeBetweenSpawns));
        //StartCoroutine(SpawnClouds(timeBetweenSpawns));
    }

    private void Update()
    {

    }

    private IEnumerator spawnBackground(float timeBetweenSpawns)
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        Vector2 spawnPosition;

        spawnPosition.x = spawnXPos;
        spawnPosition.y = plantSpawnYPos;

        cloudYPos = Random.Range(-1, 5);

        int spawnRandom = Random.Range(0, 2);
        int spawnRandomPlant = Random.Range(0, 7);

        GameObject objectToSpawn = null;

        if (spawnRandom == 0)
        {
            objectToSpawn = Instantiate(plants[spawnRandomPlant], new Vector2(spawnPosition.x, spawnPosition.y), plants[spawnRandomPlant].transform.rotation);
        }
        if (spawnRandom == 1)
        {
            for (int i = 0; i < clouds.Length; i++)
            {
                objectToSpawn = Instantiate(clouds[i], new Vector2(spawnPosition.x, cloudYPos), clouds[i].transform.rotation);
            }
        }

        StartCoroutine(spawnBackground(timeBetweenSpawns));
    }
}