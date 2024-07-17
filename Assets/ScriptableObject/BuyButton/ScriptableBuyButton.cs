using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewBuyButton", menuName = "UI_Game/BuyButton")]

public class ScriptableBuyButton : ScriptableObject
{

    //[SerializeField] private int _cost = 5;
    //[SerializeField] private int _levelUpgrade = 0;
    //[SerializeField] private int _makeAuto;
    //[SerializeField] private Sprite _buyIcon;
    //[SerializeField] private string _nameUpgrade;
    //[SerializeField] private string _nameBuff;
    //[SerializeField] private string _nameCost;

    //public string NameUpgrade => _nameUpgrade;
    //public string NameBuff => _nameBuff;
    //public string NameCost => _nameCost;
    //public int Cost => _cost;
    //public int LevelUpgrade => _levelUpgrade;
    //public int MakeAuto => _makeAuto;
    //public Sprite BuyIcon => _buyIcon;


    public int LevelUpgrade = 1;
    public string SNameUpgrade;
    public string SNameBuff;
    public string SNameCost;
    public int Cost = 5;
    public int MakeClick;
    public int MakeAuto;
    public Sprite BuyIcon;

}
