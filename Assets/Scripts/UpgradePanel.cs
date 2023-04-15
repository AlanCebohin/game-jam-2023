using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] StatBoost _upgrade;
    [SerializeField] GameObject _player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _upgrade.Activate(_player);
        }
    }
}
