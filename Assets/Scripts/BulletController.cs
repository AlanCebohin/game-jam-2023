using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRB;
    [SerializeField] private float bulletSpeed;
    private GameObject levelLimit;

    //[SerializeField] private GameObject arrowImpact; // Particle effect
    private Transform bulletTransform;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        bulletRB.velocity = bulletTransform.forward * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Instantiate(bulletImpact, bulletTransform.position, Quaternion.identity); // Particle effect
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}