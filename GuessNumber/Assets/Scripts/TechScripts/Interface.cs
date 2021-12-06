using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public TMP_Text Balance;
    public static Interface s_inst;
    public Color32 BackGroundColor;
    private void Start()
    {
        s_inst = this;
        Balance.text = $"�����: {DataManager.s_inst.Money}";
        BackGroundColor = DataManager.s_inst.BackGroundColor;
    }
    public void UpdateMoney()
    {
        Balance.text = $"�����: {DataManager.s_inst.Money}";
    }
}
