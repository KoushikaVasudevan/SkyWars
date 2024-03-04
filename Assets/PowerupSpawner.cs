using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject eaglePowerup;
    //[SerializeField] private GameObject birdsPowerup;
    //[SerializeField] private GameObject goldenGoosePowerup;
    [SerializeField] private HelicopterController helicopterController;

    [SerializeField] private float timeBetweenSpawns;

    [SerializeField] private float spawnXPos;

    private void Start()
    {
        StartCoroutine(SpawnPowerups(timeBetweenSpawns));
    }

    private void Update()
    {

    }

    private IEnumerator SpawnPowerups(float timeBetweenSpawns)
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

            //int pickupSelect = Random.Range(0, 3);

            GameObject objectToSpawn = null;

            objectToSpawn = Instantiate(eaglePowerup.gameObject, new Vector2(spawnPosition.x, spawnPosition.y), eaglePowerup.gameObject.transform.rotation);

            StartCoroutine(SpawnPowerups(timeBetweenSpawns));
        }
    }
}
