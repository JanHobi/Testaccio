using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // up and down movement with random range loop
        transform.DOLocalMoveY(0.3f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        // side to side movement with random range loop
        transform.DOLocalMoveX(0.3f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
