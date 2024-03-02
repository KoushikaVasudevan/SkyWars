using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsSpawner : MonoBehaviour
{
    [SerializeField] private HelicopterController helicopterController;
    [SerializeField] private GoldController goldController;
    [SerializeField] private float timeBetweenSpawns;

    [SerializeField] private float spawnXPos;

    private void Start()
    {
        StartCoroutine(SpawnGoldCollectible(timeBetweenSpawns));
    }

    private void Update()
    {

    }

    private IEnumerator SpawnGoldCollectible(float timeBetweenSpawns)
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
            spawnPosition.y = Random.Range(-4, 5);

            //int randomNumber = Random.Range(0, 5);

            GameObject objectToSpawn = null;

            objectToSpawn = Instantiate(goldController.gameObject, new Vector2(spawnPosition.x, spawnPosition.y), goldController.gameObject.transform.rotation);

            StartCoroutine(SpawnGoldCollectible(timeBetweenSpawns));
        }
    }
}
