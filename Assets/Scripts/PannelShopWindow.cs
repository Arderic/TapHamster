using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PannelShopWindow : MonoBehaviour
{
    [SerializeField] MassButtosShop MassButtosShop;
    [SerializeField] RectTransform ContentPunnelShop;

    public GameObject PrefabButton;

    void Start()
    {
        for(int i = 0; i < MassButtosShop.MassButton.Count; i++)
        {
            PrefabButton.name = "Button" + i;
            var SettingButton = MassButtosShop.MassButton[i];
            var LinkOnButton = Instantiate(PrefabButton, ContentPunnelShop);
            LinkOnButton.GetComponent<BuyButton>().SetSettingButton(SettingButton);
        }
    }
}
