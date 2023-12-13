using System.Linq;
using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR) 
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

            if (GUILayout.Button("Skip All Tasks"))
            {
                taskManager.SetAllTasksToDone();
            }
            GUILayout.Space(5);
            
            if (GUILayout.Button("Skip Task"))
            {
                // Get the first selected task (if any)
                var selectedTask = taskManager.SelectedTasks.FirstOrDefault(task => !task.Value);

                if (selectedTask.Key != null)
                {
                    taskManager.SetTaskToDone(selectedTask.Key);
                }
            }
            GUILayout.Space(5);
        }
    }
}
#endif
