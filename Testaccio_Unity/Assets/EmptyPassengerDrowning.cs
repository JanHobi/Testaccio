using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmptyPassengerDrowning : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        DrownPassenger();
    }

    void DrownPassenger()
    {
        // dotween smooth up down local y loop
        transform.DOLocalMoveY(0.55f, 0.2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
