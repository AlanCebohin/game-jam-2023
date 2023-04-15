using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GoTowardsPlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    public Transform _playerTransform;

    private void Update()
    {
        if (_playerTransform != null)
        {
            MoveToPlayer();
            RotateTowardsPlayer();
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (_playerTransform.position - transform.position).normalized;
        transform.Translate(0, 0, _moveSpeed * Time.deltaTime, Space.Self);
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (_playerTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

}
