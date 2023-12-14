using System;
using System.Collections.Generic;
using Animation;
using Audio;
using UI;
using UnityEngine;
using Visual;

namespace Managers
{
    public class KnobManager : MonoBehaviour
    {
        public List<GameObject> interactableObjects;
        [SerializeField] private GameObject startingCircle;
        [SerializeField] private Knob knobPrefab;
        [SerializeField] private GameObject timeCompass;
        [HideInInspector] public Dictionary<GameObject, Knob> InteractablesAndKnobs = new Dictionary<GameObject, Knob>();
        private GameObject selectedObject;


        
        // Update is called once per frame
        void Update()
        {
            CheckClickedObject();
            AddColorToSelectedObject();
        }

      

        private void CheckClickedObject()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (Camera.main == null) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if hit object is in the interactable List
                GameObject hittedObject = hit.transform.gameObject;
                if (interactableObjects.Contains(hittedObject))
                {
                    // Check if Object has Animator component
                    Animator animator = hit.transform.GetComponent<Animator>();
                           
                    if (animator != null)
                    {
                        AudioManager.Instance.PlayObjectClickSound();
                        
                        // If I clicked on a new object, remove the color from the last clicked object
                        if (hittedObject != selectedObject && selectedObject != null)
                            ObjectHighlight.RemoveClickedColor(selectedObject);
                                
                        // Add the clicked object to the variable
                        selectedObject = hittedObject;

                        if (!InteractablesAndKnobs.ContainsKey(hittedObject))
                        {
                            // Give every interactable object a Knob
                            Knob newKnob = Instantiate(knobPrefab, timeCompass.transform);
                                    
                            SelectKnob(newKnob);
                                    
                            newKnob.IntializeKnob(startingCircle, animator);
                                    
                            // add this knob to the all knobs list
                            InteractablesAndKnobs.Add(hittedObject, newKnob);
                        }

                        else
                        {
                            Knob selectedKnob = InteractablesAndKnobs[hittedObject];
                            if (selectedKnob != null) SelectKnob(selectedKnob);
                        }
                    }
                    else
                    {
                        // The object is interactable, but doesn't have an Animator component
                        Debug.Log("Clicked on an interactable object without an Animator component");
                    }
                }
                else
                {
                    if (selectedObject == null) return;
                    ObjectHighlight.RemoveClickedColor(selectedObject);
                    selectedObject = null;
                }
            }
        }

        private void SelectKnob(Knob newKnob)
        {
            foreach (var knob in InteractablesAndKnobs.Values)
            {
                if(knob == newKnob) continue;
                knob.Selected = false;
            }
            
            newKnob.Selected = true;
        }
        
        private void AddColorToSelectedObject()
        {
            if (selectedObject != null) ObjectHighlight.ChangeToClickedColor(selectedObject);
        }
    }
}
