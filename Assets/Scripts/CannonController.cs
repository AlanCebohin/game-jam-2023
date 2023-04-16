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

    public List<GameObject> enemies;

    // Angular speed in radians per sec.
    public float rotationSpeed = 1.0f;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    void Start()
    {
        if (bullet == null)
        {
            Debug.LogWarning("You forgot to assign bullet prefab to CannonController!");
        }
    }

    void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim()
    {
        enemies = UpdateEnemyList.instance.enemies;

        if (enemies == null)
            return;

        float minDistance = Mathf.Infinity;

        if (enemies.Count > 0 || enemies != null)
        {

            foreach (var e in enemies)
            {
                float distance = Vector3.Distance(m_Transform.position, e.transform.position);

                if (distance < minDistance)
                {
                    // use LookAt to rotate towards the target
                    transform.LookAt(e.transform.position);
                }
            }
        }

    }

    private void Shoot()
    {
        if (enemies != null)
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
}
