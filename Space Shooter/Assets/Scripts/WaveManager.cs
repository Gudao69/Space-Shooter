using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject newAsteroid;
        newAsteroid = Instantiate(AsteroidPrefab,transform.position,Quaternion.identity);
        newAsteroid.transform.position += new Vector3( Random.Range(-12,12) , 0, 0);


        float randomScale = Random.Range(2.5f, 3.5f);
        newAsteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        StartCoroutine(SpawnAsteroid());
    }
}
