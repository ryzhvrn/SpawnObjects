using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coin;
    public Transform[] spawnPoints;
    public float spawnDelay;

    private int _randomPosition;
    private float _currentSpawnDelay;

    private void Start()
    {
        _currentSpawnDelay = spawnDelay;
    }

    private void Update()
    {
        if (_currentSpawnDelay <= 0)
        {
            _randomPosition = Random.Range(0, spawnPoints.Length);
            Instantiate(coin, spawnPoints[_randomPosition].transform.position, Quaternion.identity);
            _currentSpawnDelay = spawnDelay;
        }
        else
        {
            _currentSpawnDelay -= Time.deltaTime;
        }
    }
}
