using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FisherTween : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(new Vector3(1f, 1.04f, 1f), 0.8f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        transform.DOLocalRotate(new Vector3(0, 0, 6), 0.6f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
