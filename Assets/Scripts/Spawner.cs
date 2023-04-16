using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyTypes;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private EnemySpawnerController _controller;
   
    private bool _spawnerBlocked;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Obstacle"))
    //    {
    //        _spawnerBlocked = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Obstacle"))
    //    {
    //        _spawnerBlocked = false;
    //    }
    //}

    public void SpawnEnemy()
    {
        Vector3 directionToPLayer = _playerTransform.position - transform.position;
        GameObject enemy = Instantiate(_enemyTypes[Random.Range(0, _enemyTypes.Length)],transform.position, Quaternion.LookRotation(directionToPLayer, Vector3.up));
        enemy.GetComponent<GoTowardsPlayer>()._playerTransform = _playerTransform;
        _controller._SpawnTimer = 0;
    }

    public bool _SpawnerBlocked
    {
        get { return _spawnerBlocked; }
    }


}
