using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnemyList : MonoBehaviour
{
    public static UpdateEnemyList instance;

    public List<GameObject> enemies;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}
