using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab; 
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    void Start()
    {
     StartCoroutine("SpawnRoutine"); 
    }

    //Spawn an enemy every 5 seconds.
    // while loop -> infinite loop that keeps going until the game ends.
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            float x = Random.Range(-8f,8f);
            Vector3 spawnPos = new Vector3(x, 8f, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);

            //wait for 5 seconds
            yield return new WaitForSeconds(5);
        }
    }

    public void OnPlayerDeath()
        {
            _stopSpawning = true;
        }
    
}