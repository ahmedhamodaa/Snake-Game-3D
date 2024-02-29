using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public float respawnTime; // Time to wait before respawning

    void Start()
    {
        SpawnApple();
    }

    // Call this method when the snake eats an apple
    public void AppleEaten()
    {
        StartCoroutine(RespawnAfterDelay());
    }

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnApple();
    }

    void SpawnApple()
    {
        Instantiate(applePrefab, GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-5f, 5f); // Range
        float z = Random.Range(-5f, 5f); // Range
        return new Vector3(x, 0.5f, z);
    }
}