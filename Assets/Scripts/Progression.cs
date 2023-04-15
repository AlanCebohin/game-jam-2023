using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
public class Progression : ScriptableObject
{
    [SerializeField] StatBonus[] _statBonuses;

    Dictionary<Stat, float[]> lookupTable = null;

    [System.Serializable]
    public class StatBonus
    {
        public Stat _stat;
        public float[] _levels;
    }

    public float GetStatBonus(Stat stat, int level)
    {
        BuildLookup();

        float[] levels = lookupTable[stat];

        if (levels.Length < level)
        {
            return 0;
        }

        return levels[level - 1];

    }

    private void BuildLookup()
    {
        if (lookupTable != null) { return; }

        lookupTable = new Dictionary<Stat, float[]>();

        foreach (StatBonus statBonus in _statBonuses)
        {
            lookupTable[statBonus._stat] = statBonus._levels;
        }
    }
}
