using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 5f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            Vector3 randomPosition = GetRandomPositionNearPlayer();
            Instantiate(powerUpPrefab, randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPositionNearPlayer()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return playerTransform.position + randomPosition;
    }
}
