using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UpgradeType
{
    ATK,
    DEF,
    UTY,
    END
}
[Serializable]
public class UpgradeBtn
{
    public string Information;
    public float Value;
    public float Price;
}

public class AbilityUpgrade : MonoBehaviour
{
    UpgradeType type = UpgradeType.ATK;

    [SerializeField] private Button leftBtn;
    [SerializeField] UpgradeBtn[] leftBtnValues = new UpgradeBtn[3];
    [SerializeField] private TextMeshProUGUI leftInformation;
    [SerializeField] private TextMeshProUGUI leftValue;
    [SerializeField] private TextMeshProUGUI leftPrice;

    [SerializeField] private Button rightBtn;
    [SerializeField] UpgradeBtn[] rightBtnValues = new UpgradeBtn[3];
    [SerializeField] private TextMeshProUGUI rightInformation;
    [SerializeField] private TextMeshProUGUI rightValue;
    [SerializeField] private TextMeshProUGUI rightPrice;

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
        }
    }
    private void WndSet()
    {
        int typeNum = ((int)type);


    }
    public void TypeChange(float num)
    {
        type = (UpgradeType)num;
        WndSet();
    }
}
