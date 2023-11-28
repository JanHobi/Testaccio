using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmallAnimations : MonoBehaviour
{
   [SerializeField] private GameObject gameObjectToAnimate;

    public void BridgeOpen()
    {
        gameObjectToAnimate.transform.DOLocalRotate(new Vector3(70, 0, 0), 0.7f).SetEase(Ease.InExpo);
    }

    public void BridgeClose()
    {
        gameObjectToAnimate.transform.DOLocalRotate(new Vector3(-22, 0, 0), 0.7f).SetEase(Ease.OutBounce);
    }
}
