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
        
        if(GUILayout.Button("Move Up"))
        {
            grid.moveUp();
        }
        if(GUILayout.Button("Move Down"))
        {
            grid.moveDown();
        }
        if(GUILayout.Button("Move Right"))
        {
            grid.moveRight();
        }
        if(GUILayout.Button("Move Left"))
        {
            grid.moveLeft();
        }

        if(GUILayout.Button("Break Block"))
        {
            //
        }

    }
}
