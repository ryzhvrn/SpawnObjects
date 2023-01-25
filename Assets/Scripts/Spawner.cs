using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Coin coinPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay;

    private int _randomPosition;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        if (coinPrefab.TryGetComponent(out Coin coin))
        {
            while (true)
            {
                _randomPosition = Random.Range(0, spawnPoints.Length);
                Instantiate(coinPrefab,spawnPoints[_randomPosition].transform.position, Quaternion.identity);

                yield return _sleepTime;
            }
        }
    }
}
