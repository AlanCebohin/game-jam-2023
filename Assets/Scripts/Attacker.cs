using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] Transform _cannonTransform;
    [SerializeField] GameObject _firingPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _cannonRotationSpeed;
    [SerializeField] float _rateOfFire = .5f;
    [SerializeField] List<GameObject> _enemyList = new List<GameObject>();

    private Transform _target;
    private Quaternion _cannonTargetDirection;
    private float _shootTimer;

    private void Update()
    {
        FindClosestEnemy();

        if (_target == null) { return; }

        RotateCannon();
        Shoot();

        _shootTimer += Time.deltaTime;
    }

    private void FindClosestEnemy()
    {

        _enemyList = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();

        if (_enemyList.Count > 0)
        {
            Transform closestEnemy = _enemyList[0].transform;

            for (int i = 0; i < _enemyList.Count; i++)
            {
                float distance = Vector3.Distance(transform.position, _enemyList[i].transform.position);
                float distanceToClosest = Vector3.Distance(transform.position, closestEnemy.transform.position);

                if (distance < distanceToClosest)
                {
                    closestEnemy = _enemyList[i].transform;
                }
            }

            _target = closestEnemy;
        }
    }

    private void RotateCannon()
    {
        Vector3 up = _cannonTransform.up;
        Vector3 directionToTarget = Vector3.ProjectOnPlane(_target.position - _cannonTransform.position, up);
        _cannonTargetDirection = Quaternion.LookRotation(directionToTarget, up);

        Quaternion from = Quaternion.LookRotation(_cannonTransform.forward, _cannonTransform.up);
        _cannonTransform.rotation = Quaternion.RotateTowards(from, _cannonTargetDirection, _cannonRotationSpeed * Time.fixedDeltaTime);

        _firingPoint.transform.LookAt(_target);
    }

    private void Shoot()
    {
        if (_target != null)
        {
            if (_shootTimer > _rateOfFire)
            {
                Instantiate(_bulletPrefab, _firingPoint.transform.position, _cannonTransform.rotation);
                _shootTimer = 0;
            }
        }
    }

}
