// AHEngine - Attribute 2017 Writed
// AHEngine Writed by Hamidreza Karamian (CoFounder , CEO AHTEAM)

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Reflection;
using System;


#if UNITY_EDITOR
    [CanEditMultipleObjects] // Don't ruin everyone's day
    [CustomEditor(typeof(MonoBehaviour), true)] // Target all MonoBehaviours and descendants
    public class MonoBehaviourCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // Draw the normal inspector

        // Get the type descriptor for the MonoBehaviour we are drawing
        var methods = target.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy);

        // Iterate over each private or public instance method (no static methods atm)
        foreach (var method in methods)
            {
               // Debug.Log(method.Name);
                // make sure it is decorated by our custom attribute
                var attributes = method.GetCustomAttributes(typeof(ExposeMethodInEditorAttribute), true);
                if (attributes.Length > 0)
                {
                    if (GUILayout.Button(method.Name))
                    {
                        if (method != null)
                            method.Invoke(target, null);
                    }
                }
            }


        methods = target.GetType().GetMethods(BindingFlags.FlattenHierarchy);

        foreach (var method in methods)
        {
            Debug.Log("Methods : " + method.Name);

            var attributes = method.GetCustomAttributes(typeof(ExposeMethodInEditorAttribute), true);
            if (attributes.Length > 0)
            { }
        }


        }


    }
#endif

[AttributeUsage(AttributeTargets.Method)]
public class ExposeMethodInEditorAttribute : Attribute
{
    public readonly string name; // Does Not Work Currently

    public ExposeMethodInEditorAttribute(string name = "")
    {
        this.name = name;
    }
}




