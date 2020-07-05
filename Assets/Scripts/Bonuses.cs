using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonuses : MonoBehaviour
{
    public bool isComplete;

    int gems;

    public Text bonusText;

    private void OnEnable()
    {
        gems = (int)Finder.GetGameManager().enemies / 10;
        if (isComplete)
            gems += 10;

        Finder.GetGameManager().gems += gems;
        bonusText.text = "+" + gems;
    }
}
