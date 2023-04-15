using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Transform m_Transform;
    [SerializeField] private GameObject bullet;

    // @TODO: Play with ShootCooldownTime when difficulty increased.
    [SerializeField] private float shootCooldownTime = 1f;
    [SerializeField] private float shootCounterTime = 0.5f;
    [SerializeField] private float shootCooldownCounter;
    [SerializeField] private float shootCounter;
    private bool isShooting = true;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    //void Start()
    //{
    //    if (bullet = null)
    //    {
    //        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    //    }
    //}

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (shootCooldownCounter > 0)
            shootCooldownCounter -= Time.deltaTime;

        else
        {
            Instantiate(bullet, m_Transform.position, m_Transform.rotation);
            shootCounter = shootCounterTime;
            isShooting = false;
        }

        if (shootCounter > 0)
        {
            shootCounter -= Time.deltaTime;
            isShooting = true;
            shootCooldownCounter = shootCooldownTime;
        }
    }
}
