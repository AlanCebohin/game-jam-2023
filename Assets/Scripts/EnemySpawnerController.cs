using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] float _spawnDelay = 1;
    [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

    private float _spawnTimer;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Spawner spawner = child.GetComponent<Spawner>();
            if (spawner != null)
            {
                _spawners.Add(spawner);
            }
        } 
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > _spawnDelay)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        List<Spawner> availableSpawners = new List<Spawner>();

        foreach (Spawner spawner in _spawners)
        {
            if (spawner._SpawnerBlocked) { continue; }
            availableSpawners.Add(spawner);
        }

        int spawnerIndex = Random.Range(0, availableSpawners.Count);

        availableSpawners[spawnerIndex].SpawnEnemy();
    }

    public float _SpawnTimer
    {
        get { return _spawnTimer; }
        set { _spawnTimer = value; }
    }
}
