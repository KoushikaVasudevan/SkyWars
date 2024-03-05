using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missile;

    [SerializeField] private HelicopterController helicopterController;

    [SerializeField] private float timeBetweenSpawns;

    [SerializeField] private float spawnXPos;

    private void Start()
    {
        StartCoroutine(SpawnMissiles(timeBetweenSpawns));
    }

    private void Update()
    {

    }

    private IEnumerator SpawnMissiles(float timeBetweenSpawns)
    {
        yield return new WaitForSeconds(timeBetweenSpawns);


        if ((helicopterController == null))
        {
            yield break;
        }

        else
        {
            Vector2 spawnPosition;

            spawnPosition.x = spawnXPos;
            spawnPosition.y = Random.Range(-4, 4);

            GameObject objectToSpawn = null;

            objectToSpawn = Instantiate(missile, new Vector2(spawnPosition.x, spawnPosition.y), missile.gameObject.transform.rotation);

            StartCoroutine(SpawnMissiles(timeBetweenSpawns));
        }
    }
}

