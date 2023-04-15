using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    public int xpToNextLevel = 100;
    public int currentXP = 0;
    public Slider xpBarSlider;
    
    [SerializeField] TextMeshProUGUI _currentLevelElement;
    [SerializeField] TextMeshProUGUI _healthLevelElement;
    [SerializeField] TextMeshProUGUI _rustElement;
    [SerializeField] Sprite _Testicon;
    [SerializeField] GameObject _upgradeSelect;

    [SerializeField] List<GameObject> _upgrades = new List<GameObject>();

    private void Start() {
        //addXP(currentXP);
        //setLevel(2);
        //setHealth(20, 100);
        //setRust(40);
        //setUpgrades("Power UP", "This will do stuff 01", _Testicon, "Power UP2", "This will do stuff 02", _Testicon,"Power UP3", "This will do stuff 03", _Testicon );
    }

    public void addXP(float XP)
    {
        xpBarSlider.value = XP;
    }

    public void setLevel(int level)
    {
        _currentLevelElement.text = "LEVEL " + level.ToString();
    }

    public void setHealth(float setCurrentHealth, float setMaxHealth)
    {
        _healthLevelElement.text = "HEALTH " + Mathf.FloorToInt(setCurrentHealth).ToString() + "/" + Mathf.FloorToInt(setMaxHealth).ToString();
    }

    public void setRust(float setCurrentRust)
    {
        _rustElement.text = "RUST METER " + Mathf.FloorToInt(setCurrentRust).ToString() + "/100";
    }

    public void setUpgrades(string upgradeTypeText1, string upgradeDesp1, Sprite upgradeIcon1,
                            string upgradeTypeText2, string upgradeDesp2, Sprite upgradeIcon2,
                            string upgradeTypeText3, string upgradeDesp3, Sprite upgradeIcon3)
    {
        foreach (GameObject gameObject in _upgrades)
        {
            TextMeshProUGUI typeUpgradeText = gameObject.transform.Find("TypeUpgradeText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI upgradeDesp = gameObject.transform.Find("UpgradeDesp").GetComponent<TextMeshProUGUI>();
            Image upgradeIconImage = gameObject.transform.Find("UpgradeIcon").GetComponent<Image>();

            switch (gameObject.name) 
            {
                case "UpgradeSingle01":
                    typeUpgradeText.text = upgradeTypeText1;
                    upgradeDesp.text = upgradeDesp1;
                    upgradeIconImage.sprite = upgradeIcon1;
                    break;
                case "UpgradeSingle02":
                    typeUpgradeText.text = upgradeTypeText2;
                    upgradeDesp.text = upgradeDesp2;
                    upgradeIconImage.sprite = upgradeIcon2;
                    break;
                case "UpgradeSingle03":
                    typeUpgradeText.text = upgradeTypeText3;
                    upgradeDesp.text = upgradeDesp3;
                    upgradeIconImage.sprite = upgradeIcon3;
                    break;
                default:
                    break;
            }
        }
        _upgradeSelect.SetActive(true);
    }

    public void closeUpgradePanel() 
    {
        _upgradeSelect.SetActive(false);
    }

}
