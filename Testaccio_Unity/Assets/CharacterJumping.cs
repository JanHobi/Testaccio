using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterJumping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveY(0.4f, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }
}
