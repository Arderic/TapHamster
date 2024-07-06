using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game : MonoBehaviour
{
    [SerializeField] int Score;
    private int ClickScore = 1;
    private int MakeAuto = 0;
    public Text ScoreText;
    public TextMeshProUGUI AutoText;


    private void Awake()
    {
        
    }
    private void Start()
    {
        StartCoroutine(AutoShop());
    }

    public void OnClicHamster()
    {
        Score += ClickScore;
    }

    private void Update()
    {
        ScoreText.text = Score + "$";
        AutoText.text = MakeAuto + " Какашек в секунду";
}
    public void OnClick(BuyButton buyButton)
    {
        if (Score >= buyButton.GetCost() * buyButton.GetLvl())
        {
            Score -= buyButton.GetCost() * buyButton.GetLvl();

            if (buyButton.GetMakeAuto() != 0) MakeAuto += buyButton.GetMakeAuto();
            else ClickScore += buyButton.GetMakeClick();
            //buyButton.IncreasCost();
            buyButton.LvlUp();
        }
    }



    IEnumerator AutoShop()
    {
        while (true)
        {
            Score += MakeAuto;
            yield return new WaitForSeconds(1);
        }
    }
}
