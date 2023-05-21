using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabThief = default;
    [SerializeField] private GameObject prefabKnight = default;
    [SerializeField] private GameObject prefabPriest = default;
    [SerializeField] private GameObject enemyContainer = default;

    public GameObject player;

    private bool stopSpawn = false;
    private float initialDelay = 10.0f;
    private float minDelay = 5f;
    private float delayMultiplier = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(initialDelay);

        float currentDelay = initialDelay;

        while (stopSpawn == false)
        {
            SpawnEnemy(prefabThief);
            SpawnEnemy(prefabKnight);
            SpawnEnemy(prefabPriest);

            yield return new WaitForSeconds(currentDelay);

            currentDelay = Mathf.Max(currentDelay * delayMultiplier, minDelay);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 enemySpawn = new Vector3(Random.Range((player.transform.position.x + 2) - 8f, player.transform.position.x + 8f),
                                         Random.Range(player.transform.position.y - 8f, player.transform.position.y + 8f),
                                         player.transform.position.z + Random.Range(-2f, 2f));

        GameObject newEnemy = Instantiate(enemyPrefab, enemySpawn, Quaternion.identity);
        newEnemy.transform.parent = enemyContainer.transform;
        newEnemy.SetActive(true);
    }

    public void EndEnemySpawn()
    {
        stopSpawn = true;
    }
}