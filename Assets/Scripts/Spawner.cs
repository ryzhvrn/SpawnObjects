using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay;

    private int _randomPosition;
    private int _destroyObjectPosition = -10;

    private void Start()
    {

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            _randomPosition = Random.Range(0, spawnPoints.Length);
            GameObject coin = Instantiate(coinPrefab, spawnPoints[_randomPosition].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);

            if (coin.transform.position.y < -_destroyObjectPosition)
            {
                Destroy(coin);
            }
        }
    }
}
