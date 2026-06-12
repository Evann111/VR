using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] fruitPrefabs; // Pastèque, orange, citron...
    public GameObject bombPrefab;

    [Header("Settings")]
    public float spawnInterval = 1.5f;
    public float bombChance = 0.15f; // 15% de chance bombe
    public Transform[] spawnPoints; // Points autour du joueur

    private bool spawning = true;

    void Start() => InvokeRepeating(nameof(SpawnFruit), 1f, spawnInterval);

    void SpawnFruit()
    {
        if (!spawning) return;

        // Choisir un point de spawn aléatoire
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Bombe ou fruit ?
        GameObject prefab = Random.value < bombChance
            ? bombPrefab
            : fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

        GameObject fruit = Instantiate(prefab, spawnPoint.position, Random.rotation);

        // Lancer le fruit vers le joueur
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        Vector3 playerPos = FindObjectOfType<Camera>().transform.position;
        Vector3 direction = (playerPos - spawnPoint.position).normalized;
        rb.linearVelocity = direction * Random.Range(3f, 6f);
        rb.angularVelocity = Random.insideUnitSphere * 3f;

        // Détruire si pas tranché après 4 secondes
        Destroy(fruit, 4f);
    }

    public void StartSpawning()
    {
        spawning = true;
        InvokeRepeating(nameof(SpawnFruit), 1f, spawnInterval);
    }

    public void StopSpawning()
    {
        spawning = false;
        CancelInvoke();
    }
}