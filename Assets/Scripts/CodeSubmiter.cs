using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeSubmiter : MonoBehaviour
{
    public Text input;

    public void Submit()
    {
        FindObjectOfType<GameManager>().Submit(input.text);
    }
}
