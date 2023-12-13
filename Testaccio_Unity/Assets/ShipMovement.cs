using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMoveY(0.4f, 0.8f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
