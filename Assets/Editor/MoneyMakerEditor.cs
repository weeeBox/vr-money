using UnityEngine;
using UnityEditor;

using System.Collections;

[CustomEditor(typeof(MoneyMaker))]
public class MoneyMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Update"))
        {
            MoneyMaker maker = target as MoneyMaker;
            maker.MakeMoney();
        }
    }
}
