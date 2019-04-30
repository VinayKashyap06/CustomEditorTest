using UnityEngine;
using UnityEditor;
using System;

namespace Testing
{
    [CustomEditor(typeof(TestScript))]
    public class TestScriptEditor : Editor
    {      
        private EditorGUILayout.FadeGroupScope group;       
        public override void OnInspectorGUI()
        {
            TestScript testScriptInstance = (TestScript)target;

            testScriptInstance.canShow = EditorGUILayout.Toggle("Show properties", testScriptInstance.canShow);
           

            using (group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(testScriptInstance.canShow)))
            {
                if (group.visible == true)
                {                    
                    testScriptInstance.color = EditorGUILayout.ColorField("Color", testScriptInstance.color);                   
                    testScriptInstance.number = EditorGUILayout.IntField("Number", testScriptInstance.number);          
                    testScriptInstance.testEnum = (TestEnum)EditorGUILayout.EnumPopup("Test Enum", testScriptInstance.testEnum);
                }
            }

            testScriptInstance.canDisable = EditorGUILayout.Toggle(testScriptInstance.canDisable, "Disable Name");
            EditorGUI.BeginDisabledGroup(testScriptInstance.canDisable);
            testScriptInstance.testName = EditorGUILayout.TextField("Test Name", testScriptInstance.testName);           
            EditorGUI.EndDisabledGroup();           

        }


    }
}