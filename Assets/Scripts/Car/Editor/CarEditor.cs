using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Car myTarget = (Car)target;
        
        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("Velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade Total", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calcule a velocidade total do carro!", MessageType.Info);

        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Velocidade acima do permitido", MessageType.Error);
        }

        GUI.color = Color.blue;
        
        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }

        GUI.color = Color.yellow;
        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }

    }


#if UNITY_EDITOR
    [UnityEditor.MenuItem("MyMenu/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }

    [UnityEditor.MenuItem("MyMenu/Test 2 %g")]
    public static void Test2()
    {
        Debug.Log("Test2");
    }
#endif
}
