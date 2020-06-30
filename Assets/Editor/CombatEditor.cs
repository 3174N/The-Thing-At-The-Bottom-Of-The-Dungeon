using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Combat))]
public class CombatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Combat combat = (Combat)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("DAMAGE"))
        {
            combat.ChangeHealth(-10);
        }
        GUILayout.EndHorizontal();
    }
}
