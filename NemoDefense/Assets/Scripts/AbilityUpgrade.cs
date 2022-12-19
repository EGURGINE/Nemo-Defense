using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UpgradeType
{
    ATK,
    DEF,
    UTY,
    END
}

public class AbilityUpgrade : MonoBehaviour
{
    UpgradeType type = UpgradeType.ATK;

    [SerializeField] private Button[] typeBtn = new Button[3];

    [SerializeField] private Button leftBtn; 
    [SerializeField] private Button rightBtn;

    private void Awake()
    {
        leftBtn.onClick.AddListener(() => LeftBtnSet());
        rightBtn.onClick.AddListener(() => RightBtnSet());
    }

    private void LeftBtnSet() 
    {
        switch (type)
        {
            case UpgradeType.ATK:
                break;
            case UpgradeType.DEF:
                break;
            case UpgradeType.UTY:
                break;
            case UpgradeType.END:
                break;
            default:
                break;
        }
    }
    private void RightBtnSet() 
    {
        switch (type)
        {
            case UpgradeType.ATK:
                break;
            case UpgradeType.DEF:
                break;
            case UpgradeType.UTY:
                break;
            case UpgradeType.END:
                break;
            default:
                break;
        }
    }
}
