using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] UIcontroller _UiController;
    [SerializeField] StatBoost[] _upgrades;
    [SerializeField] GameObject _player;

    private StatBoost _upgrade1;
    private StatBoost _upgrade2;
    private StatBoost _upgrade3;

    public void GetReward()
    {
        StatBoost upgrade1 = _upgrades[Random.Range(0, _upgrades.Length)];
        StatBoost upgrade2 = _upgrades[Random.Range(0, _upgrades.Length)];
        StatBoost upgrade3 = _upgrades[Random.Range(0, _upgrades.Length)];

        _upgrade1 = upgrade1;
        _upgrade2 = upgrade2;
        _upgrade3 = upgrade3;

        _UiController.setUpgrades(upgrade1._Name, upgrade1._Description, upgrade1._ThumbNail, upgrade2._Name, upgrade2._Description, upgrade2._ThumbNail, upgrade3._Name, upgrade3._Description, upgrade3._ThumbNail);
    }

    public void ClickUpgrade1()
    {
        _upgrade1.Activate(_player);
        _UiController.closeUpgradePanel();
    }

    public void ClickUpgrade2()
    {
        _upgrade2.Activate(_player);
        _UiController.closeUpgradePanel();
    }
    public void ClickUpgrade3()
    {
        _upgrade3.Activate(_player);
        _UiController.closeUpgradePanel();
    }

    public StatBoost _Upgrade1
    {
        get { return _upgrade1; }
    }
    public StatBoost _Upgrade2
    {
        get { return _upgrade2; }
    }
    public StatBoost _Upgrade3
    {
        get { return _upgrade3; }
    }
}
