using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] Collider[] _overlappingColliders;
    [SerializeField] Vector3 _halfExtents = new Vector3(299, 0, 299);
    [SerializeField] private List<GameObject> _tiles;
    [SerializeField] float _spawnRange;
    [SerializeField] float _tileRance;
    [SerializeField] LayerMask _tileLayer;

    [SerializeField] private Transform _player;
    public Transform _Player
    {
        get { return _player; }
    }

    [SerializeField] private GameObject _instantiatedTile;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        if (!CheckForTiles())
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        int tileIndex = Random.Range(0, _tiles.Count);
        _instantiatedTile = Instantiate(_tiles[tileIndex], transform.position, Quaternion.identity);
        _instantiatedTile.GetComponent<DestroyTile>()._Player = _player;
    }

    private bool CheckForTiles()
    {
        Collider[] overlappingColliders = Physics.OverlapBox(transform.position, _halfExtents, Quaternion.identity, _tileLayer);
        _overlappingColliders = overlappingColliders;

        if (overlappingColliders.Length > 1)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(598, 0, 598));
    }
}
