using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRB;
    [SerializeField] private float bulletSpeed;
    private GameObject levelLimit;
    [SerializeField] private float damagePower = 5;

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
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            
            if (enemy.hp > 0)
            {
                enemy.hp -= damagePower;
            }
            else if (enemy.hp <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}