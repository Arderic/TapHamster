using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PannelShopWindow : MonoBehaviour
{
    [SerializeField] MassButtosShop MassButtosShop;
    [SerializeField] RectTransform ContentPunnelShop;
    [SerializeField] private GameData gameData;
    //[SerializeField] private ButtonProgress buttonProgress;
    public GameObject PrefabButton;

    void Start()
    {
        ButtonProgress buttonProgress = gameData.GetButtonProgress();
        for (int i = 0; i < MassButtosShop.MassButton.Count; i++)
        {
            PrefabButton.name = MassButtosShop.MassButton[i].name;
            var SettingButton = MassButtosShop.MassButton[i];
            var LinkOnButton = Instantiate(PrefabButton, ContentPunnelShop);
            LinkOnButton.GetComponent<BuyButton>().SetSettingButton(SettingButton, i, buttonProgress.Buttons[i]);
        }
        
    }
}
