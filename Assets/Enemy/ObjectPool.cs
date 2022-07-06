using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            Instantiate(enemyPrefab, this.transform);
            yield return new WaitForSeconds(spawnTimer);
            
        }
    }

}
