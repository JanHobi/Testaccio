using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleTween : MonoBehaviour
{
    [SerializeField] private Image accidents;
    [SerializeField] private Image edition;


    
    void Start()
    {
        transform.DOShakePosition(0.5f, 5f, 20, 90f, false, false).SetDelay(1f).OnComplete(() => 
        {
                
            accidents.rectTransform.DOAnchorPosY(-15, 0.5f).SetEase(Ease.OutBack);

            edition.rectTransform.DOScale(1, 0.25f).SetEase(Ease.InQuad);

            edition.DOFade(1, 0.25f).SetEase(Ease.InQuad).OnComplete(() => 
            {
                edition.rectTransform.DOScale(1.03f, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
            });
        });

    }
}
