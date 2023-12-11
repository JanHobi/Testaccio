using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TaxiShake : MonoBehaviour
{
    void Start()
    {
        transform.DOShakePosition(1f, new Vector3(0, 0.15f, 0), 15, 90, false, false).SetLoops(-1, LoopType.Yoyo);
    }
}
