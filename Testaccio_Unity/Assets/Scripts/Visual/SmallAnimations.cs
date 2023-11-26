using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmallAnimations : MonoBehaviour
{
   [SerializeField] private GameObject gameObjectToAnimate;
   bool isTransitioning = false;

    public void BridgeOpen()
    {

        Debug.Log("BridgeOpen");
        isTransitioning = true;
        gameObjectToAnimate.transform.DOLocalRotate(new Vector3(70, 0, 0), 0.7f).SetEase(Ease.OutBounce).OnComplete(() => isTransitioning = false);
    }

    public void BridgeClose()
    {
        Debug.Log("BridgeClose");
        isTransitioning = true;
        gameObjectToAnimate.transform.DOLocalRotate(new Vector3(-30, 0, 0), 0.7f).SetEase(Ease.OutBounce).OnComplete(() => isTransitioning = false);
    }
}
