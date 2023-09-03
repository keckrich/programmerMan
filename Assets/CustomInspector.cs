using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Movement))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //EditorGUILayout.LabelField("Hey!");

        Movement grid = (Movement)target;
        if (GUILayout.Button("Move Up"))
        {
            grid.MoveUp();
        }
        if (GUILayout.Button("Move Down"))
        {
            grid.MoveDown();
        }
        if (GUILayout.Button("Move Right"))
        {
            grid.MoveRight();
        }
        if (GUILayout.Button("Move Left"))
        {
            grid.MoveLeft();
        }

    }
}

[CustomEditor(typeof(NewPlayer))]
public class CustomInspecto2r : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //EditorGUILayout.LabelField("Hey!");

        NewPlayer grid = (NewPlayer)target;
        if (GUILayout.Button("Move Up"))
        {
            grid.WalkForward();
        }
        if (GUILayout.Button("Move Down"))
        {
            grid.WalkDown();
        }
        if (GUILayout.Button("Move Right"))
        {
            grid.WalkRight();
        }
        if (GUILayout.Button("Move Left"))
        {
            grid.WalkLeft();
        }

    }
}
