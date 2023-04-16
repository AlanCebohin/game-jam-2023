using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] Progression _progression;
    [SerializeField] UIcontroller _UiController;
    [SerializeField] UpgradePanel _upgradePanel;

    [SerializeField]  private int _level = 1;
    private float _rust = 0;

    private float _rustIncrease = 10;

    private float _rustTimer = 0;
    private float _rustInterval = 20f;
    private float _healthRegenTimer = 0;
    private float _healthRegenInterval = 5f;

    [SerializeField]  private float _rustResistance = 5;
    private int _rustResistanceLevel = 0;

    [SerializeField] private float _attackSpeed = 1f;
    private int _attackSpeedLevel = 0;

    [SerializeField] private float _healthRegen = 10;
    private int _healthRegenLevel = 0;

    private float _experience = 0;
    private int _experienceToLevelUp = 100;

    private int _statMaxLevel = 10;

    private Health _health;

    private void Awake()
    {
        _UiController.setLevel(_level);
        _UiController.setRust(_rust);
        _UIController.addXP(_experience);
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        _rustTimer += Time.deltaTime;
        _healthRegenTimer += Time.deltaTime;

        if (_rustTimer > _rustInterval)
        {
            Rusting();
        }

        if (_healthRegenTimer > _healthRegenInterval)
        {
            HealthRegen();
            _healthRegenTimer = 0;
        }
    }


    public void GainExperience(float experienceGained)
    {
        _experience += experienceGained;

        _UIController.addXP(_experience / _level);

        if (_experience > (_experienceToLevelUp * _level))
        {
            LevelUp();
        }

    }

    private void LevelUp()
    {
        _level++;
        _UIController.setLevel(_level);
        _upgradePanel.GetReward();
        _experience = 0;
        _UIController.ResetXP();
    }

    public void Rusting()
    {
        _rust += _rustIncrease - _rustResistance;
        _rustTimer = 0;
        _UiController.setRust(_rust);
    }

    private void HealthRegen()
    {
        _health.RegenHealth(_healthRegen);
    }

    public void UpgradeStat(Stat stat)
    {
        float statBonus;

        switch (stat)
        {
            case Stat.AttackSpeed:
                statBonus = _progression.GetStatBonus(stat, _attackSpeedLevel);
                _attackSpeed -= statBonus;
                if (_attackSpeedLevel < _statMaxLevel)
                {
                    _attackSpeedLevel++;
                }
                Debug.Log(stat + " got a boost of" + statBonus + " and is now: " + _attackSpeed + " and has a level of: " + _attackSpeedLevel);
                break;
            case Stat.HealthRegen:
                statBonus = _progression.GetStatBonus(stat, _healthRegenLevel);
                _healthRegen += statBonus;
                if (_healthRegenLevel < _statMaxLevel)
                {
                    _healthRegenLevel++;
                }
                break;
            case Stat.RustResistance:
                statBonus = _progression.GetStatBonus(stat, _rustResistanceLevel);
                _rustResistance += statBonus;
                if (_rustResistanceLevel < _statMaxLevel)
                {
                    _rustResistanceLevel++;
                }
                break;
            default:
                break;
        }
    }

    public int _Level
    {
        get { return _level; }
    }

    public float _Rust
    {
        get { return _rustResistance; }
    }

    public float _AttackSpeed
    {
        get { return _attackSpeed; }
    }

    public float _HealthRegen
    {
        get { return _healthRegen; }
    }

    public float _Experience
    {
        get { return _experience; }
    }

    public UIcontroller _UIController
    {
        get { return _UiController;}
    }
}