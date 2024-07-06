using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private ScriptableBuyButton _buttonSetting;

    [SerializeField] private int Level = 1;

    public TextMeshProUGUI NameUpgrade;
    public TextMeshProUGUI NameBuff;
    public TextMeshProUGUI NameCost;

    private void Awake()
    {

        _button = this.GetComponent<Button>();
        _button.onClick.AddListener(() => {
            FindObjectOfType<Game>().OnClick(this);
            NameUpgrade.text = _buttonSetting.SNameUpgrade;
            if (_buttonSetting.MakeAuto != 0) NameBuff.text = _buttonSetting.SNameBuff;
            else NameBuff.text = _buttonSetting.SNameBuff;
            NameCost.text = _buttonSetting.Cost * Level + "$";
        });

    }


    public void SetSettingButton(ScriptableBuyButton ButtonSetting)
    {
        _buttonSetting = ButtonSetting;
        NameUpgrade.text = _buttonSetting.SNameUpgrade;
        if (_buttonSetting.MakeAuto != 0) NameBuff.text = _buttonSetting.SNameBuff;
        else NameBuff.text = _buttonSetting.SNameBuff;
        NameCost.text = _buttonSetting.Cost * Level + "$";
    }
    
    public int GetCost()
    {
        return _buttonSetting.Cost;
    }

    public int GetMakeAuto()
    {
        return _buttonSetting.MakeAuto;
    }
    public int GetMakeClick()
    {
        return _buttonSetting.MakeClick;
    }

    public void LvlUp()
    {
        Level += 1;
    }
    public int GetLvl()
    {
        return Level;
    }
}
