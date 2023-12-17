using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellerTween : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(new Vector3(1f, 1.06f, 1f), 0.7f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
