using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlinkingTween : MonoBehaviour
{
    [SerializeField] private float invokeTime = 0.5f;
    [SerializeField] private float blinkTime = 0.3f;
    [SerializeField] private float eyeOriginalRotation = -40f;
    [SerializeField] private float eyeGoalRotation = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Blink", invokeTime);
    }

    void Blink()
    {
        // rotate local x to 90 degrees in 1 second
        transform.DOLocalRotate(new Vector3(eyeGoalRotation, 0, 0), blinkTime).SetEase(Ease.InExpo).OnComplete(() =>
        {
            // rotate local x to 0 degrees in 1 second
            transform.DOLocalRotate(new Vector3(eyeOriginalRotation, 0, 0), blinkTime).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                // repeat
                Invoke("Blink", invokeTime);
            });
        });
    }
}
