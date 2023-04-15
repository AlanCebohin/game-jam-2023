using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] Progression _progression;

    private int _level;

    private float _rustResistance;
    private int _rustResistanceLevel;

    private float _attackSpeed;
    private int _attackSpeedLevel;

    private float _healthRegen;
    private int _healthRegenLevel;

    private float _experience;

    private int _statMaxLevel = 10;

    public void GainExperience(int experienceGained)
    {
        _experience += experienceGained;
    }

    public void UpgradeStat(Stat stat)
    {
        float statBonus;

        switch (stat)
        {
            case Stat.AttackSpeed:
                statBonus = _progression.GetStatBonus(stat, _attackSpeedLevel);
                _attackSpeed += statBonus;
                if (_attackSpeedLevel < _statMaxLevel)
                {
                    _attackSpeedLevel++;
                }
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
}