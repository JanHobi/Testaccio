using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Managers
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<string> allTasks = new List<string>();
        [HideInInspector] public List<string> selectedTasks = new List<string>();
        [HideInInspector] public Dictionary<string, bool> TasksAndBools = new Dictionary<string, bool>();
        
        
        private void Awake()
        {
            foreach (var task in allTasks)
            {
                TasksAndBools.Add(task, false);
            }
        }
        
        void Start()
        {
            // Generate three random indices and add corresponding tasks to selectedTasks
            selectedTasks = Enumerable.Range(0, 3)
                .Select(_ => allTasks[Random.Range(0, TasksAndBools.Count)])
                .ToList();
        }
    }
}
