using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _barPrefab;
    [SerializeField] private GameObject[] _spawnPoints;

    private float spawnDelay = 1.5f;
    private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnBars", spawnDelay, spawnInterval);
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
}
