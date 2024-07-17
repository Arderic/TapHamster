using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private const string SaveButtonsKey = "SaveButtons";
    private ButtonProgress _buttonProgress = new();
    [SerializeField] MassButtosShop MassButtosShop;

    public void SetStartDataScore()
    {
        _buttonProgress = GetButtonProgress();
        FindObjectOfType<Game>().SetScore(_buttonProgress.Money);
        SaveData();
    }
    public void SetButtonStartData(BuyButton buybutton, int index)
    {
        _buttonProgress = GetButtonProgress();
        buybutton.SetLvl(_buttonProgress.Buttons[index].Level);
        FindObjectOfType<Game>().SetAutoMake(_buttonProgress.Buttons[index].Level, index, buybutton);
        FindObjectOfType<Game>().SetClickMake(_buttonProgress.Buttons[index].Level, index, buybutton);
        SaveData();
    }

    //public void SetMainStartData(int index)
    //{
    //    _buttonProgress = GetButtonProgress();
    //    FindObjectOfType<Game>().SetScore(_buttonProgress.Money);

    //    SaveData();
    //}

    public void SetDataScore(Game _game)
    {
        _buttonProgress = GetButtonProgress();
        _buttonProgress.Money = _game.GetScore();
        SaveData();
    }
    public void SetDataButton(BuyButton buybutton, int index)
    {
        _buttonProgress = GetButtonProgress();
        _buttonProgress.Buttons[index].Level += 1;
        SaveData();
    }

    public void DeleteData()
    {

        PlayerPrefs.DeleteAll();
        
    }
    private void SaveData() 
    {
        string saveJson = JsonUtility.ToJson(_buttonProgress);
        PlayerPrefs.SetString(SaveButtonsKey, saveJson);
        PlayerPrefs.Save();
        //File.WriteAllText("test.json", saveJson);
    }

    public void NewData()
    {
        for (int i = 0; i < FindObjectOfType<Game>().GetComponent<MassButtosShop>().MassButton.Count; i++)
        {
            Progress NewProgress = new Progress();
            NewProgress.Level = 1;
            _buttonProgress.Buttons.Add(NewProgress);
        }
        _buttonProgress.Money = 0;
        SaveData();
    }

    public ButtonProgress GetButtonProgress()
    {
        if(PlayerPrefs.HasKey(SaveButtonsKey))
        {
            string saveJson = PlayerPrefs.GetString(SaveButtonsKey);
            _buttonProgress = JsonUtility.FromJson<ButtonProgress>(saveJson);
        }
        else
        {
            NewData();
        }

        return _buttonProgress;
    }
}
