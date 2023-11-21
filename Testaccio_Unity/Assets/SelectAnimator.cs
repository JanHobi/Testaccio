using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimator : MonoBehaviour
{
    [SerializeField] private List<GameObject> interactableObjects;
    [HideInInspector] public Animator selectedAnimator;

    // Update is called once per frame
    void Update()
    {
        CheckClickedObject();
    }

    private void CheckClickedObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if hit object is in the interactable List
                    if (interactableObjects.Contains(hit.transform.gameObject))
                    {
                      // Check if Object has Animator component
                      Animator animator = hit.transform.GetComponent<Animator>();
                      
                      if (animator != null)
                      {
                          // Store the found Animator in the public variable
                          selectedAnimator = animator;

                          // The object is interactable and has an Animator component
                          Debug.Log("Clicked on an interactable object with an Animator component");
                      }
                      else
                      {
                          // The object is interactable, but doesn't have an Animator component
                          Debug.Log("Clicked on an interactable object without an Animator component");
                      }
                    }
                    else
                    {
                        // The clicked object is not in the list of interactable objects
                        Debug.Log("Clicked on a non-interactable object");
                    }
                }
            }
        }
    }
}
