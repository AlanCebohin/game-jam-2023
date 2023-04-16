using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] UIcontroller _UiController;
    [SerializeField] StatBoost[] _upgrades;
    [SerializeField] GameObject _player;

    public void GetReward()
    {
        StatBoost upgrade1 = _upgrades[Random.Range(0, _upgrades.Length)];
        StatBoost upgrade2 = _upgrades[Random.Range(0, _upgrades.Length)];
        StatBoost upgrade3 = _upgrades[Random.Range(0, _upgrades.Length)];

        _UiController.setUpgrades(upgrade1._Name, upgrade1._Description, upgrade1._ThumbNail, upgrade2._Name, upgrade2._Description, upgrade2._ThumbNail, upgrade3._Name, upgrade3._Description, upgrade3._ThumbNail);
    }
}
