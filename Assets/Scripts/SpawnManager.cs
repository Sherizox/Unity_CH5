using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private GameManager gameManager;

    private float spawnDelay = 1.0f; 

   
    private IEnumerator SpawnTarget(float difficulty)
    {
        while (!gameManager.IsGameOver())
        {
            yield return new WaitForSeconds(spawnDelay / difficulty);
            int targetIndex = Random.Range(0, targets.Length);
            Instantiate(targets[targetIndex], targets[targetIndex].transform.position, targets[targetIndex].transform.rotation);
        }
    }

 
    public void StartSpawning(float difficulty)
    {
        StartCoroutine(SpawnTarget(difficulty));
    }
}
