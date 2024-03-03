using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _barPrefab;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject _heartPrefab;

    private float barsSpawnDelay = 1.5f;
    private float barsSpawnInterval = 2f;
    private float xRange = 12f;
    private float lifeSpawnDelay = 5f;
    private float lifeSpawnInterval = 7f;

    private void Start()
    {
        InvokeRepeating("SpawnBars", barsSpawnDelay, barsSpawnInterval);
        InvokeRepeating("SpawnLife", lifeSpawnDelay, lifeSpawnInterval);
    }

    private void SpawnBars()
    {
        List<int> usedIndices = new List<int>();
        for (int i = 0; i < _spawnPoints.Length - 1; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = (int)Random.Range(0f, (float)_spawnPoints.Length);
            } while (usedIndices.Contains(randomIndex));
            usedIndices.Add(randomIndex);

            Instantiate(_barPrefab, _spawnPoints[randomIndex].transform.position, Quaternion.identity);
        }
        usedIndices.Clear();
    }

    private void SpawnLife()
    {
        Instantiate(_heartPrefab, new Vector3(Random.Range(-xRange, xRange), -8.5f, 0f), Quaternion.identity);
    }
}
