using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _healthPoints;
    private float _maxHealthPoints;

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    public void RegenHealth(float regeneratedHealth)
    {
        if (_healthPoints < _maxHealthPoints)
        {
            _healthPoints = Mathf.Min(_maxHealthPoints, _healthPoints + regeneratedHealth);
        }
    }

    public void Die()
    {
        Debug.Log("Player has died");
    }

    public float _HealthPoints
    {
        get { return _healthPoints; }
        set { _healthPoints = value; }
    }

    public float _MaxHealthPoints
    {
        get { return _maxHealthPoints; }
        set { _maxHealthPoints = value; }
    }
}
