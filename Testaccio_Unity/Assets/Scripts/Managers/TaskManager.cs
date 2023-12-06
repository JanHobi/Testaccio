using System;
using System.Collections.Generic;
using System.Linq;
using Animation;
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
        private TaskAnimations taskAnimations;
      

       
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

            taskAnimations = GetComponent<TaskAnimations>();
        }

        void Start()
        {
            NewTasks();
        }

        private void CheckTasksCompletion()
        {
            // Check tasks that are on screen
            bool allTasksCompleted = SelectedTasks.All(task => task.Value);
            if (!allTasksCompleted) return;
            
            // Check if ALL, like really ALL tasks are completed
            if (allTasks.Count <= 0)
            {
                Debug.Log("All tasks completed!");
                // Game finished
                GameManager.instance.currentGameState = GameManager.GameState.GameWon;
            }

            // Wait some seconds before getting new tasks, so that the animation can finish
            Invoke(nameof(NewTasks), 3);
        }

        public void SetTaskToDone(string taskKey)
        {
            if (SelectedTasks.ContainsKey(taskKey))
            {
                // Only consider it if the task has not been done
                if ( SelectedTasks[taskKey] == true) return;
               
                SelectedTasks[taskKey] = true;
                
                // Check if it has a UI element
                TMP_Text uiText = FindUITextByTaskKey(taskKey);

                if (uiText != null)
                {
                  taskAnimations.TaskDoneAnimation(uiText);
                }
                
                // Check if all Tasks are done now
                CheckTasksCompletion();
            }
            else
            {
                Debug.LogWarning($"Task with key '{taskKey}' not found.");
            }
        }

        private TMP_Text FindUITextByTaskKey(string taskKey)
        {
            // Find the TMP Object that has this Key stored. Or simpler: Find the UI-Text of a given Task
            return (from Transform child in taskParent select child.GetComponent<TMP_Text>())
                .FirstOrDefault(uiText => uiText != null && uiText.text == taskKey);
        }

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
                int randomIndex = Random.Range(0, numberOfTasksShown-1);
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
        
        public void SetAllTasksToDone()
        {
            // Only for Debugging and Testing
            foreach (var key in SelectedTasks.Keys.ToList())
            {
                SelectedTasks[key] = true;
                SetTaskToDone(key);
            }
            
            CheckTasksCompletion();
        }

    }
}
