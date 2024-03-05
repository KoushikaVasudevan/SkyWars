using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missile;

    //[SerializeField] private HelicopterController helicopterController;
    [SerializeField] private float gooseCoolDownTime = 5f;
    [SerializeField] private float activeGooseTime;

    [SerializeField] private float timeBetweenSpawns;

    [SerializeField] private float spawnXPos;
    [SerializeField] private bool isGoldenGooseActive;

    private void Start()
    {
        activeGooseTime = gooseCoolDownTime;

        isGoldenGooseActive = false;
        StartCoroutine(SpawnMissiles(timeBetweenSpawns));
    }

    private void Update()
    {
        if(isGoldenGooseActive)
        {
            activeGooseTime -= Time.deltaTime;

            if(activeGooseTime <= 0)
            {
                isGoldenGooseActive = false;
                activeGooseTime = gooseCoolDownTime;
            }
        }
    }

    private IEnumerator SpawnMissiles(float timeBetweenSpawns)
    {
        yield return new WaitForSeconds(timeBetweenSpawns); 

        if(!isGoldenGooseActive)
        {
            Vector2 spawnPosition;

            spawnPosition.x = spawnXPos;
            spawnPosition.y = Random.Range(-4, 4);

            GameObject objectToSpawn = null;
            objectToSpawn = Instantiate(missile, new Vector2(spawnPosition.x, spawnPosition.y), missile.transform.rotation);
        }

        StartCoroutine(SpawnMissiles(timeBetweenSpawns));
    }

    public void ActivateGoldenGoose()
    {
        isGoldenGooseActive = true;
    }
}

