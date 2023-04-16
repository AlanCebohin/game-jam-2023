using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject PlayerImpact; // Particle effect

    private void Start()
    {
        if (PlayerImpact == null)
        {
            Debug.LogWarning("PlayerImpact Prefab is empty!");
        }
    }

    private void OnEnable()
    {
        if (damage == 0)
        {
            damage = 10;
            Debug.LogWarning("Damage not set, defaulting to 10");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Instantiate(PlayerImpact, collision.transform.position, Quaternion.identity); // Particle effect
            Destroy(gameObject);
        }
    }
}
