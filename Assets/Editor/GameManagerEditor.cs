using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager manager = (GameManager)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("SAVE"))
        {
            manager.SaveShop();
        }

        if (GUILayout.Button("LOAD"))
        {
            manager.LoadShop();
        }
        GUILayout.EndHorizontal();
    }
}
