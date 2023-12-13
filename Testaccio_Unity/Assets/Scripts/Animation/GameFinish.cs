using System.Collections.Generic;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Animation
{
    public class GameFinish : MonoBehaviour
    {
        private TaskManager taskManager;
        [SerializeField] private RectTransform endMenu;
        private readonly List<GameObject> objectsToRemove = new List<GameObject>();

        void Start()
        {
            taskManager = GetComponent<TaskManager>();
            
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("RemoveAtEnd");
            objectsToRemove.AddRange(objectsWithTag);
        }

        public void ShowEndScreen()
        {
            if (!taskManager.gameFinished) return;
           
            GameManager.instance.SetState(GameManager.GameState.GameWon);
            endMenu.gameObject.SetActive(true);
            endMenu.DOAnchorPos(new Vector2(0, 0), 2f).SetEase(Ease.InOutQuint);
            
            foreach (var obj in objectsToRemove)
            {
                obj.SetActive(false);
            }
        }
    }
}
