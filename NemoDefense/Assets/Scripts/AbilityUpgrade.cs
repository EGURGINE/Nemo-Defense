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

public class AbilityUpgrade : MonoBehaviour
{
    private UpgradeType type = UpgradeType.ATK;

    [SerializeField] private Button leftBtn;
    [SerializeField] private UpgradeBtn leftBtnData;
    [SerializeField] UpgradeBtn[] leftBtnValues = new UpgradeBtn[3];
    [SerializeField] private TextMeshProUGUI leftInformation;
    [SerializeField] private TextMeshProUGUI leftValue;
    [SerializeField] private TextMeshProUGUI leftPrice;

    [Space(10f)]

    [SerializeField] private Button rightBtn;
    [SerializeField] private UpgradeBtn rightBtnData;
    [SerializeField] UpgradeBtn[] rightBtnValues = new UpgradeBtn[3];
    [SerializeField] private TextMeshProUGUI rightInformation;
    [SerializeField] private TextMeshProUGUI rightValue;
    [SerializeField] private TextMeshProUGUI rightPrice;

    [Space(10f)]

    [SerializeField] private Image upgradeTypeInformationBG;
    [SerializeField] private Color[] upgradeTypeInformationBGColor;
    [SerializeField] private TextMeshProUGUI upgradeTypeInformationTxt;

    private void Awake()
    {
        leftBtn.onClick.AddListener(() => LeftBtnSet());
        rightBtn.onClick.AddListener(() => RightBtnSet());

        StartSet();
        WndSet();
    }

    private void StartSet()
    {
        Player.Instance.state.dmg = leftBtnValues[0].Value;
        Player.Instance.state.hp = leftBtnValues[1].Value;
        Player.Instance.state.moneyBonus = leftBtnValues[2].Value;
        Player.Instance.state.shotSpd = rightBtnValues[0].Value;
        Player.Instance.state.regeneration = rightBtnValues[1].Value;
        Player.Instance.state.waveMoney = rightBtnValues[2].Value;
    }

    private void LeftBtnSet() 
    {
        if(GameManager.Instance.Money < leftBtnData.Price) return;
        GameManager.Instance.Money -= leftBtnData.Price;

        leftBtnData.Price += rightBtnData.Price * 1.5f;



        leftBtnData.Value += 0.01f;
        switch (type)
        {
            case UpgradeType.ATK:
                Player.Instance.state.dmg = leftBtnData.Value;
                break;
            case UpgradeType.DEF:
                Player.Instance.state.hp = leftBtnData.Value;
                break;
            case UpgradeType.UTY:
                Player.Instance.state.moneyBonus = leftBtnData.Value;
                break;
        }


        WndSet();
    }
    private void RightBtnSet() 
    {
        if(GameManager.Instance.Money < rightBtnData.Price) return;
        GameManager.Instance.Money -= rightBtnData.Price;

        rightBtnData.Price += rightBtnData.Price * 1.5f;
        rightBtnData.Value += 0.01f;


        switch (type)
        {
            case UpgradeType.ATK:
                Player.Instance.state.shotSpd = rightBtnData.Value;
                break;
            case UpgradeType.DEF:
                Player.Instance.state.regeneration = rightBtnData.Value;

                if (Player.Instance.regenerationCoroutine == null)
                    Player.Instance.regenerationCoroutine = StartCoroutine(Player.Instance.Regeneration());
                break;
            case UpgradeType.UTY:
                Player.Instance.state.waveMoney = rightBtnData.Value;
                break;
        }

        WndSet();
    }
    private void WndSet()
    {
        int typeNum = ((int)type);

        upgradeTypeInformationTxt.text = $"{type} UPGRADE";
        upgradeTypeInformationBG.color = upgradeTypeInformationBGColor[typeNum];

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
