using System.Collections.Generic;
using Animation;
using UI;
using UnityEngine;

namespace Managers
{
    public class KnobManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> interactableObjects;
        [SerializeField] private GameObject startingCircle;
        [SerializeField] private Knob knobPrefab;
        [SerializeField] private GameObject timeCompass;
        [HideInInspector] public Dictionary<GameObject, Knob> InteractablesAndKnobs = new Dictionary<GameObject, Knob>();
        

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
                        GameObject hittedObject = hit.transform.gameObject;
                        if (interactableObjects.Contains(hittedObject))
                        {
                            // Check if Object has Animator component
                            Animator animator = hit.transform.GetComponent<Animator>();
                           
                            if (animator != null)
                            {

                                if (!InteractablesAndKnobs.ContainsKey(hittedObject))
                                {
                                    // Give every interactable object a Knob
                                    Knob newKnob = Instantiate(knobPrefab, timeCompass.transform);
                                    
                                    newKnob.IntializeKnob(startingCircle, animator);
                                    
                                    // add this knob to the all knobs list
                                    InteractablesAndKnobs.Add(hittedObject, newKnob);

                                    SelectKnob(newKnob);

                                    Debug.Log("added new line in dictionary: " + hittedObject + knobPrefab);
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
                    }
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
    }
}
