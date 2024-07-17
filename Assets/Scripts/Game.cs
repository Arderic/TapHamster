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
    [SerializeField] MassButtosShop MassButtosShop;

    private void Awake()
    {
        FindObjectOfType<GameData>().SetStartDataScore();
    }
    private void Start()
    {
        StartCoroutine(AutoShop());
        StartCoroutine(SaveScore());
    }

    public void OnClicHamster()
    {
        Score += ClickScore;
    }

    //public void SetStartGameSetting()
    //{
    //    for(int i = 0; i < MassButtosShop.MassButton.Count; i++)
    //    {
    //        FindObjectOfType<GameData>().SetMainStartData(i);
    //    }
    //}
    public void SetScore(int _score)
    {
        Score += _score;
    }
    public void SetAutoMake(int lvl, int index, BuyButton buybutton)
    {
        MakeAuto += buybutton.GetMakeAuto() * (lvl - 1);
    }
    public void SetClickMake(int lvl, int index, BuyButton buybutton)
    {
        ClickScore += buybutton.GetMakeClick() * (lvl - 1);
    }

    public int GetScore()
    {
        return Score;
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

    IEnumerator SaveScore()
    {
        while (true)
        {
            FindObjectOfType<GameData>().SetDataScore(this);
            yield return new WaitForSeconds(1);           
        }
    }
}
