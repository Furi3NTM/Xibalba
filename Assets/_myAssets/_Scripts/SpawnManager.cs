using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject prefabThief = default;
    [SerializeField] private GameObject prefabKnight = default;
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
            Vector3 theifSpawn = new Vector3(Random.Range(player.transform.position.x - 5f, player.transform.position.x + 5f), 7f, player.transform.position.z + Random.Range(-2f, 2f));
            GameObject newTheif = Instantiate(prefabThief, theifSpawn, Quaternion.identity);
            newTheif.transform.parent = enemyContainer.transform;

            Vector3 knightSpawn = new Vector3(Random.Range(player.transform.position.x - 5f, player.transform.position.x + 5f), 7f, player.transform.position.z + Random.Range(-2f, 2f));
            GameObject newKnight = Instantiate(prefabKnight, knightSpawn, Quaternion.identity);
            newKnight.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(8.0f, 20.0f));
        }

    }

    public void EndEnemySpawn()
    {
        stopSpawn = true;
    }


}
