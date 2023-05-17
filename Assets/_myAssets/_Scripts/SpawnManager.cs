using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject prefabEnemy = default;
    [SerializeField] private GameObject prefabEnemyKight = default;
    [SerializeField] private GameObject enemyContainer = default;

    public GameObject player;

    private bool stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /* create a couroutine */
    IEnumerator SpawnEnemyRoutine()
    {
        /* wait 3 second between first enemy */
        yield return new WaitForSeconds(1.0f);

        while (stopSpawn == false)
        {
            Vector3 positionSpawn = new Vector3(Random.Range(player.transform.position.x - 5f, player.transform.position.x + 5f), 7f, player.transform.position.z + Random.Range(-2f, 2f));
            GameObject newEnemy = Instantiate(prefabEnemy, positionSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;

            GameObject newKight = Instantiate(prefabEnemyKight, positionSpawn, Quaternion.identity);
            newKight.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(8.0f, 20.0f));
        }

    }

    public void EndEnemySpawn()
    {
        stopSpawn = true;
    }


}
