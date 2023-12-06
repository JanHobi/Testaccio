using UnityEditor;
using UnityEngine;

namespace Managers
{
    [CustomEditor((typeof(TaskManager)))]
    public class TaskManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            TaskManager taskManager = (TaskManager) target;
            
            // Button
            GUILayout.Space(10);

            if (GUILayout.Button("Tasks Done"))
            {
                taskManager.SetTasksToDone();
            }
            GUILayout.Space(10);
        }
    }
}
