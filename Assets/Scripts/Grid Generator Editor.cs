using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

[CustomEditor(typeof(GridGenerator))]

public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridGenerator gridGenerator = (GridGenerator)target;
        if(GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
        
        if(GUILayout.Button("Clear Grid"))
        {
            gridGenerator.ClearGrid();
        }
        
        if(GUILayout.Button("Assign Material"))
        {
            gridGenerator.AssignMaterial();
        }

    }

    [MenuItem("Tools/Generate Grid")]
    public static void GenerategridMenu()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();
        if(gridGenerator != null)
        {
            gridGenerator.GenerateGrid();
        }

        else
        {
            Debug.LogError("No Grid Generator Found in Scene");
        }
    }
}
