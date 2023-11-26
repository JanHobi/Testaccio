using System;
using System.Collections;
using System.Collections.Generic;
using Animation;
using UI;
using UnityEngine;

public class SelectAnimator : MonoBehaviour
{
    [SerializeField] private List<GameObject> interactableObjects;
    [HideInInspector] public Animator selectedAnimator;
    private AnimationManager animationManager;
    private KnobMove knobMove;
    [SerializeField] private GameObject timeCompass;


    private void Start()
    {
        KnobMove.stopCircling = true;
        animationManager = GetComponent<AnimationManager>();
        knobMove = GetComponent<KnobMove>();
    }

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
                      KnobMove.stopCircling = false;
                      
                      if (animator != null)
                      {
                          
                          GameObject knob = knobMove.knob;

                          if (!knobMove.InteractablesAndKnobs.ContainsKey(hit.transform.gameObject))
                          {
                              // Give every interactable object a Knob
                              Instantiate(knob, timeCompass.transform);
                          
                              // Set it active
                              knob.SetActive(true);
                          
                              // add this knob to the all knobs list
                              knobMove.InteractablesAndKnobs.Add(hit.transform.gameObject, knob);
                              
                              Debug.Log("added new line in dictionary: " + hit.transform.gameObject + knob);
                          }
                          
                          
                          // Store the found Animator in the public variable
                          selectedAnimator = animator;
                          
                          // Call the Get function
                          animationManager.GetSelectedAnimator();
                          
                          // Apply the before stored circle size of this object
                          //animationManager.ApplyStoredCircleSizes();
                          
                          // Jump the knob to the position of the selected animator's timeline
                          //KnobMove.JumpToAnimator(selectedAnimator);
                          
                      }
                      else
                      {
                          // The object is interactable, but doesn't have an Animator component
                          Debug.Log("Clicked on an interactable object without an Animator component");
                      }
                    }
                }
            }
        }
    }
}
