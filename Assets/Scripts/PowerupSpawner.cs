using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject eaglePowerup;
    [SerializeField] private EagleController eagleController;

    [SerializeField] private MissileSpawner missileSpawner;
    [SerializeField] private RewardsSpawner rewardsSpawner;

    [SerializeField] private GameObject birdsPowerup;
    [SerializeField] private GameObject goldenGoosePowerup;

    [SerializeField] private GameObject flockOfBirds;
    
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

            int spawnRandomPowerup = Random.Range(0, 3);

            GameObject objectToSpawn = null;

            if(spawnRandomPowerup == 0)
            {
                objectToSpawn = Instantiate(eaglePowerup, new Vector2(spawnPosition.x, spawnPosition.y), eaglePowerup.transform.rotation);
                objectToSpawn.GetComponent<EaglePowerupController>().eagleController = eagleController;
            }
            else if (spawnRandomPowerup == 1)
            {
                objectToSpawn = Instantiate(goldenGoosePowerup, new Vector2(spawnPosition.x, spawnPosition.y), goldenGoosePowerup.transform.rotation);
                objectToSpawn.GetComponent<GoldenGoosePowerupController>().missileSpawner = missileSpawner;
                objectToSpawn.GetComponent<GoldenGoosePowerupController>().rewardsSpawner = rewardsSpawner;
            }
            else if(spawnRandomPowerup == 2)
            {
                objectToSpawn = Instantiate(birdsPowerup, new Vector2(spawnPosition.x, spawnPosition.y), birdsPowerup.transform.rotation);
                objectToSpawn.GetComponent<BirdsPowerupController>().FlockOfBirds = flockOfBirds;
            }

            StartCoroutine(SpawnPowerups(timeBetweenSpawns));
        }
    }
}
