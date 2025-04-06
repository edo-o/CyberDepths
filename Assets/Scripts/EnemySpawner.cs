using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    private Camera MainCamera;


    void Start()
    {
        MainCamera = Camera.main;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Vector3 spawnPosition = spawnPoint.position;
        Vector3 screenPosition = MainCamera.WorldToScreenPoint(spawnPosition);
        Vector3 worldPosition = MainCamera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0; // Set z to 0 for 2D
        GameObject enemy = Instantiate(enemyPrefab, worldPosition, Quaternion.identity);
        enemy.transform.position = spawnPosition;
    }
}
