using UnityEngine;

[CreateAssetMenu(fileName = "Btn Datas", menuName = "Scriptable Object/Btn Data", order = int.MaxValue)]
public class UpgradeBtn : ScriptableObject
{
    public string Information;
    public float Value;
    public float Price;
}