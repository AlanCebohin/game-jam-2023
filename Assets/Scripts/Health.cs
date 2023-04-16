using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _healthPoints = 100;
    private float _maxHealthPoints = 100;

    private UIcontroller _UiController;

    private void Awake()
    {
        _UiController = GetComponent<PlayerStat>()._UIController;
        _UiController.setHealth(_healthPoints, _maxHealthPoints);
    }

    public void TakeDamage(float damage)
    {
        _healthPoints -= damage;

        _UiController.setHealth(_healthPoints, _maxHealthPoints);

        if (_healthPoints <= 0)
        {
            Die();
            GameManager.instance.GameOver();
        }

        Debug.Log("Player took " + damage + "Damage");
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
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = false;
        StartCoroutine(Drown());
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

    IEnumerator Drown()
    {
        float rotateSpeed = 10f;
        while (transform.rotation.eulerAngles.x < 90f)
        {
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
