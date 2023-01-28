using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private int _randomPosition;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        if (_coinPrefab.TryGetComponent(out Coin coin))
        {
            while (true)
            {
                _randomPosition = Random.Range(0, _spawnPoints.Length);
                Instantiate(_coinPrefab,_spawnPoints[_randomPosition].transform.position, Quaternion.identity);

                yield return _sleepTime;
            }
        }
    }
}
