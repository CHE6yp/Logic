using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(LogicalElement), true), CanEditMultipleObjects]
public class LogicalElementInspector : Editor
{
    void OnInspectorGUI()
    {
        LogicalElement script = (LogicalElement)target;
        Object obj = EditorGUILayout.ObjectField("Light", (Object)script.inputElement, typeof(IOneOutput), true);
        //script.inputElement = obj as IOneOutput;
        DrawDefaultInspector();
    }
}