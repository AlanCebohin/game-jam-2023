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

    public string _Name
    {
        get { return _name; }
    }

    public string _Description
    {
        get { return _description; }
    }

    public Sprite _ThumbNail
    {
        get { return _thumbNail; }
    }
}
