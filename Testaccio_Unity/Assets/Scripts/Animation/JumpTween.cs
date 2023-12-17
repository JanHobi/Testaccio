using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpTween : MonoBehaviour
{
    private void Start()
    {
        Invoke("Jump", Random.Range(0.5f, 2f));
    }

    void Jump()
    {
        transform.DOScale(new Vector3(1f, 1.07f, 1f), 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalMoveY(26f, 0.5f).SetEase(Ease.OutExpo).SetLoops(-1, LoopType.Yoyo);
    }
}
