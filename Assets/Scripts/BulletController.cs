using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRB;
    [SerializeField] private float bulletSpeed;
    private GameObject levelLimit;

    [SerializeField] private GameObject EnemyImpact; // Particle effect
    private Transform bulletTransform;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        bulletRB.velocity = bulletTransform.forward * bulletSpeed;
        if (EnemyImpact == null)
        {
            Debug.LogWarning("EnemyImpact Prefab is empty!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(EnemyImpact, collision.transform.position, Quaternion.identity); // Particle effect
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}