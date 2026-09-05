using UnityEngine;
using System.Collections;

public class DummySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject dummyPrefab;
    public float spawnInterval = 5f; 
    public Vector2 spawnAreaBounds = new Vector2(20f, 20f); 

    void Start()
    {
      
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(spawnInterval);
            SpawnDummy();
        }
    }

    void SpawnDummy()
    {
        if (dummyPrefab == null) return;


        float randomX = Random.Range(-spawnAreaBounds.x, spawnAreaBounds.x);
        float randomZ = Random.Range(-spawnAreaBounds.y, spawnAreaBounds.y);
        
       
        Vector3 spawnPosition = new Vector3(randomX, 1f, randomZ); 

        Instantiate(dummyPrefab, spawnPosition, Quaternion.identity);
    }
}