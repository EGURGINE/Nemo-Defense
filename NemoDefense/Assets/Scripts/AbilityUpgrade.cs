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

[CreateAssetMenu(fileName = "Btn Datas", menuName = "Scriptable Object/Btn Data", order = int.MaxValue)]
public class UpgradeBtn : ScriptableObject
{
    public string Information;
    public float Value;
    public float Price;
}

public class AbilityUpgrade : MonoBehaviour
{
    UpgradeType type = UpgradeType.ATK;

    [SerializeField] private Button leftBtn;
    [SerializeField] private UpgradeBtn leftBtnData;
    [SerializeField] UpgradeBtn[] leftBtnValues = new UpgradeBtn[3];
    [SerializeField] private TextMeshProUGUI leftInformation;
    [SerializeField] private TextMeshProUGUI leftValue;
    [SerializeField] private TextMeshProUGUI leftPrice;

    [SerializeField] private Button rightBtn;
    [SerializeField] private UpgradeBtn rightBtnData;
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
        if(GameManager.Instance.Money < leftBtnData.Price) return;



        GameManager.Instance.Money -= leftBtnData.Price;

        leftBtnData.Price += 5f;
        WndSet();
    }
    private void RightBtnSet() 
    {
        if(GameManager.Instance.Money < rightBtnData.Price) return;


        GameManager.Instance.Money -= rightBtnData.Price;

        rightBtnData.Price += 5f;
        WndSet();
    }
    private void WndSet()
    {
        int typeNum = ((int)type);

        leftBtnData = leftBtnValues[typeNum];
        rightBtnData = rightBtnValues[typeNum];

        leftInformation.text = leftBtnValues[typeNum].Information.ToString();
        leftValue.text = leftBtnValues[typeNum].Value.ToString();
        leftPrice.text = leftBtnValues[typeNum].Price.ToString();
        
        rightInformation.text = rightBtnValues[typeNum].Information.ToString();
        rightValue.text =  rightBtnValues[typeNum].Value.ToString();
        rightPrice.text =  rightBtnValues[typeNum].Price.ToString();

    }
    public void TypeChange(float num)
    {
        type = (UpgradeType)num;
        WndSet();
    }
}
