using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public GameObject sergeantPrefab;
    public float spawnInterval = 1.0f;
    public float sergeantSpawnChanceIncrement = 0.01f; // Incremental increase in sergeant spawn chance per second
    private float sergeantSpawnChance = 0.0f; // Initial sergeant spawn chance

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
            IncreaseSergeantSpawnChance();
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        if (spawnPoint != null)
        {
            GameObject enemyPrefab = Random.value < sergeantSpawnChance ? sergeantPrefab : soldierPrefab;
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return null;

        int randomIndex = Random.Range(0, childCount);
        return transform.GetChild(randomIndex);
    }

    private void IncreaseSergeantSpawnChance()
    {
        sergeantSpawnChance += sergeantSpawnChanceIncrement;
        sergeantSpawnChance = Mathf.Clamp(sergeantSpawnChance, 0.0f, 1.0f); // Clamp the value to ensure it stays between 0 and 1
    }
}
