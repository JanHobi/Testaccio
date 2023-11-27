using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationSpeed : MonoBehaviour
{


    [SerializeField] private Animator animator;
    [SerializeField] private float animationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;
    }
}
