using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;

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
            Destroy(gameObject);
        }
    }
}
