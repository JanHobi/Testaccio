using System;
using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;

namespace Animation
{
    public class TaskAnimations : MonoBehaviour
    {
        
        private GameFinish gameFinish;

        private void Start()
        {
            gameFinish = GetComponent<GameFinish>();
        }

        public void TaskDoneAnimation(TMP_Text uiText)
        {
            uiText.rectTransform.DOShakeRotation(0.1f, 1.5f, 100, 50)
                .OnComplete(() => MoveOutOfScreen(uiText));
        }

        private void MoveOutOfScreen(TMP_Text uiText)
        {
            uiText.rectTransform.position = new Vector3(-600, 650, 0);
            uiText.fontSize = 60;
            uiText.alignment = TextAlignmentOptions.Center;
            MoveTaskIntoScreen(uiText);
        }

        private void MoveTaskIntoScreen(TMP_Text uiText)
        {
            uiText.rectTransform.DOAnchorPos(new Vector2(-30, uiText.rectTransform.anchoredPosition.y), 0.5f).OnComplete(() => StrikeThrough(uiText))
                .SetEase(Ease.InOutQuint);
        }

        private void StrikeThrough(TMP_Text uiText)
        {
            StartCoroutine(WaitAndStrikeThrough());
            IEnumerator WaitAndStrikeThrough()
            {
                yield return new WaitForSeconds(0.5f);
                uiText.fontStyle = FontStyles.Strikethrough;
                StartCoroutine(routine: WaitAndMoveAway()); 
            }
            IEnumerator WaitAndMoveAway()
            {
                yield return new WaitForSeconds(2);
              
                uiText.rectTransform.DOAnchorPos(new Vector2(2020, uiText.rectTransform.anchoredPosition.y), 0.5f)
                    .SetEase(Ease.InOutQuint).OnComplete(gameFinish.ShowEndScreen);
            }
        }

        public void MoveToStartPos(TMP_Text uiText)
        {
            uiText.rectTransform.DOAnchorPos(new Vector2(1850, uiText.rectTransform.anchoredPosition.y), 0.5f)
                .SetEase(Ease.InOutQuint);
        }
    }
}
