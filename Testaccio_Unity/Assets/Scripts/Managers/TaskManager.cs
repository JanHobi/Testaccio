using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;


namespace Managers
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<string> allTasks = new List<string>();
        private Dictionary<string, bool> SelectedTasks = new Dictionary<string, bool>();
        [SerializeField] private int numberOfTasksShown;
         private float spacing = 30;
        [SerializeField] private TMP_Text uiTaskPrefab;
        [SerializeField] private Transform taskParent;
      

       
        private static TaskManager _instance;

        public static TaskManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.Log("Taskmanager is null!");
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        
       

        void Start()
        {
            NewTasks();
        }

        public void CheckTasksCompletion()
        {
            bool allTasksCompleted = SelectedTasks.All(task => task.Value == true);

            if (allTasksCompleted)
            {
                // All tasks are completed
                Debug.Log("All tasks completed!");
            }
        }

        public Dictionary<string, bool> CurrentTasks()
        {
            return SelectedTasks;
        }

        [ContextMenu("Spawn New Tasks")]
        public void NewTasks()
        {
            // Clear existing UI elements
            ClearUI();
            
            // Clear dictionary
            SelectedTasks.Clear();
            
            // Generate new tasks from Pool and then display them
            SelectedTasks = GetTasksFromPool();
            ShowTasksAsUI();
        }

        private void ClearUI()
        {
            foreach (Transform child in taskParent)
            {
               Destroy(child.gameObject);
            }
        }

        private Dictionary<string, bool> GetTasksFromPool()
        {
            if (numberOfTasksShown > allTasks.Count)
            {
                numberOfTasksShown = allTasks.Count;
            }
            
            for (int i = 0; i < numberOfTasksShown; i++)
            {
                int randomIndex = Random.Range(0, numberOfTasksShown);
                string selectedTask = allTasks[randomIndex];
                
                // Add to dictionary
                SelectedTasks.Add(selectedTask, false);
                
                // Remove the new found tasks from the Pool of possible tasks
                allTasks.RemoveAt(randomIndex);
            }
            return (SelectedTasks);
        }
        
        private void ShowTasksAsUI()
        {
           
            float yPosOffset = 0f;
            
            foreach (var tasks in SelectedTasks.Keys)
            {
                TMP_Text newtext = Instantiate(uiTaskPrefab, taskParent);
                newtext.text = tasks;

                var position = uiTaskPrefab.transform.position;
                newtext.rectTransform.anchoredPosition = new Vector2(position.x, position.y -yPosOffset);

                yPosOffset += spacing;
            }
        }
    }
}
