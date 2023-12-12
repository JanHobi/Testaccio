using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Animation
{
    public class TaskAnimations : MonoBehaviour
    {
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
            uiText.rectTransform.DOMove(new Vector3(950, uiText.rectTransform.position.y, 0), 1f).SetEase((Ease.InOutQuint))
                .OnComplete(() => StrikeThrough(uiText));
        }

        private void StrikeThrough(TMP_Text uiText)
        {
            uiText.fontStyle = FontStyles.Strikethrough;
            StartCoroutine(routine: WaitAndMoveAway()); 
            
            IEnumerator WaitAndMoveAway()
            {
                yield return new WaitForSeconds(2);
                uiText.rectTransform.DOMove(new Vector3(3000, uiText.rectTransform.position.y, 0), 1).SetEase((Ease.InOutQuint));
            }
        }
    }
}
