using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;
    public float timeScaleFactor = 0.1f; // Adjusts how quickly spawn frequency increases over time
    public float maxScaleMultiplier = 2f; // Maximum scale multiplier for spawned prefabs
    private float timer;
    private float elapsedTime;

    private void Start()
    {
        timer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timer)
        {
            SpawnPrefab();

            // Adjust spawn timer
            timer = Random.Range(minSpawnInterval, maxSpawnInterval);
            // Decrease minSpawnInterval and maxSpawnInterval over time
            minSpawnInterval *= 1 - timeScaleFactor;
            maxSpawnInterval *= 1 - timeScaleFactor;

            // Ensure spawn intervals don't go below 0.5 seconds
            minSpawnInterval = Mathf.Max(0.5f, minSpawnInterval);
            maxSpawnInterval = Mathf.Max(0.5f, maxSpawnInterval);

            // Increase the scale of the prefab
            float scaleFactor = Mathf.Min(1f + elapsedTime * timeScaleFactor, maxScaleMultiplier);
            prefabToSpawn.transform.localScale *= scaleFactor;

            elapsedTime = 0f;
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
