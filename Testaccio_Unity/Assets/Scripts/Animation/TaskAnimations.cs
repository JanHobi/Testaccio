using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Animation
{
    public class TaskAnimations : MonoBehaviour
    {
        public void TaskDoneAnimation(TMP_Text uiText)
        {
            uiText.transform.DOShakeRotation(1, 1.5f, 100, 50)
                .OnComplete(() => StrikeThrough(uiText));
        }

        private void StrikeThrough(TMP_Text uiText)
        {
            uiText.fontStyle = FontStyles.Strikethrough;
        }

        public void MoveTasksAway(TMP_Text uiText)
        {
            uiText.transform.DOMove(new Vector3(3500, uiText.transform.position.y, 0), 1).SetEase(Ease.InOutBack);
        }
    }
}
