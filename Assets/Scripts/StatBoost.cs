using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/New StatBoost", order = 0)]
public class StatBoost : Upgrade
{
    [SerializeField] Stat _stat;

    public override void Activate(GameObject caller)
    {
        caller.GetComponent<PlayerStat>().UpgradeStat(_stat);
    }
}

