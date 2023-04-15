using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DestroyTile : MonoBehaviour
{
    [SerializeField] float _distanceToPlayer;
    [SerializeField] float _destroyRange;
    [SerializeField] private LayerMask _spawnerLayer;
    [SerializeField] private Collider[] _overlappingColliders;

    private Transform _player;
    private Vector3 _halfExtents = new Vector3(300, 0, 300);

    public Transform _Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Start()
    {
        if (_player == null)
        {
            _player = GetComponentInChildren<TileSpawner>()._Player;
        }
    }

    private void Update()
    {
        if (!CheckForSpawnerColliders())
        {
            Destroy(gameObject);
        }
    }

    private bool CheckForSpawnerColliders()
    {
        Collider[] overlappingColliders = Physics.OverlapBox(transform.position, _halfExtents, Quaternion.identity, _spawnerLayer);
        _overlappingColliders = overlappingColliders;

        if (overlappingColliders.Length > 1)
        {
            return true;
        }

        return false;
    }
}
