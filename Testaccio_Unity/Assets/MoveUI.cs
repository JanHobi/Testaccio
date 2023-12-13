using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUI : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image arrowUp;
    [SerializeField] private Image arrowDown;

    private void Start()
    {
        MoveUIUp();
    }

    public void MoveUIUp()
    {
        background.rectTransform.DOAnchorPosY(-395f, 0.4f).SetEase(Ease.OutBack);
        
        arrowDown.raycastTarget = true;

        arrowUp.DOFade(0, 0.2f).SetEase(Ease.InQuad).OnComplete(() => 
        {
            arrowDown.DOFade(1, 0.2f).SetEase(Ease.InQuad);
            arrowUp.raycastTarget = false;
        });
    }
    
    public void MoveUIDown()
    {
        background.rectTransform.DOAnchorPosY(-670f, 0.4f).SetEase(Ease.InBack);

        arrowUp.raycastTarget = true;
        
        arrowDown.DOFade(0, 0.2f).SetEase(Ease.InQuad).OnComplete(() => 
        {
            arrowUp.DOFade(1, 0.2f).SetEase(Ease.InQuad);
            arrowDown.raycastTarget = false;
        });
    }

    public void ArrowEnter()
    {
        arrowDown.rectTransform.DOAnchorPosY(-19f, 0.2f).SetEase(Ease.OutBack);
        arrowUp.rectTransform.DOAnchorPosY(10f, 0.2f).SetEase(Ease.OutBack);
    }

    public void ArrowExit()
    {
        arrowDown.rectTransform.DOAnchorPosY(0f, 0.2f).SetEase(Ease.OutBack);
        arrowUp.rectTransform.DOAnchorPosY(-9f, 0.2f).SetEase(Ease.OutBack);
    }    
}
