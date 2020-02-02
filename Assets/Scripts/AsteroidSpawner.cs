using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnDelay = 5f;
    private float nextAsteroid = 0f;



    // Update is called once per frame
    void Update()
    {
        if (nextAsteroid > 0) {
            nextAsteroid -= Time.deltaTime;
        }
        if (nextAsteroid <= 0) {
            Instantiate(asteroidPrefab, transform.position, Quaternion.identity, null);
            nextAsteroid = spawnDelay;
        }
    }
}
