using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonProgress
{
    public List<Progress> Buttons = new();
    public int Money;
}

[System.Serializable]
public class Progress
{
    public int Level;
}
