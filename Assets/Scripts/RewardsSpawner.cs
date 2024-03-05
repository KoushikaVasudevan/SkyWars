using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsSpawner : MonoBehaviour
{
    [SerializeField] private HelicopterController helicopterController;
    [SerializeField] private GameObject gold;
    [SerializeField] private float timeBetweenSpawns;
    
    [SerializeField] private float spawnXPos;
    [SerializeField] private bool isGoldenGooseActive;
    [SerializeField] private float gooseCoolDownTime = 5f;
    [SerializeField] private float activeGooseTime;

    private void Start()
    {
        activeGooseTime = gooseCoolDownTime;

        isGoldenGooseActive = false;
        StartCoroutine(SpawnGoldCollectible(timeBetweenSpawns));
    }

    private void Update()
    {
        if (isGoldenGooseActive)
        {
            activeGooseTime -= Time.deltaTime;

            if (activeGooseTime <= 0)
            {
                isGoldenGooseActive = false;
                activeGooseTime = gooseCoolDownTime;
            }
        }
    }

    private IEnumerator SpawnGoldCollectible(float timeBetweenSpawns)
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        if (isGoldenGooseActive)
        {
            timeBetweenSpawns = 1;
        }
        else if (!isGoldenGooseActive)
        {
            timeBetweenSpawns = 5;
        }

        Vector2 spawnPosition;

        spawnPosition.x = spawnXPos;
        spawnPosition.y = Random.Range(-4, 4);

        GameObject objectToSpawn = null;
        objectToSpawn = Instantiate(gold, new Vector2(spawnPosition.x, spawnPosition.y), gold.transform.rotation);

        StartCoroutine(SpawnGoldCollectible(timeBetweenSpawns));
    }

    public void ActivateGoldenGoose()
    {
        isGoldenGooseActive = true;
    }
}
