using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialItem : MonoBehaviour
{
    public TextItem[] texts;

    public GameObject canvas;
    public Text textUI;

    bool hasShown;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hasShown)
            return;

        StartCoroutine(Display());

        hasShown = true;
    }

    IEnumerator Display()
    {
        foreach (TextItem text in texts)
        {
            canvas.SetActive(true);

            textUI.text = text.text;
            textUI.color = text.color;

            yield return new WaitForSeconds(text.duration);
        }

        canvas.SetActive(false);
    }
}
