using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/New Upgrade", order = 0)]
public class Upgrade : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] string _description;
    [SerializeField] Sprite _thumbNail;

    public virtual void Activate(GameObject caller)
    {
        Debug.Log(_name + " Activated!");
    }
}
