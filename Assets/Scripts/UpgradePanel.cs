using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] UIcontroller _UiController;
    [SerializeField] StatBoost _upgrade;
    [SerializeField] GameObject _player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _UiController.setUpgrades(_upgrade._Name, _upgrade._Description, _upgrade._ThumbNail, _upgrade._Name, _upgrade._Description, _upgrade._ThumbNail, _upgrade._Name, _upgrade._Description, _upgrade._ThumbNail);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _UiController.closeUpgradePanel();
        }
    }
}
