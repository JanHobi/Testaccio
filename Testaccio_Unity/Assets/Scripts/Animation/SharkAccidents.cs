using FMODUnity;
using Managers;
using UnityEngine;

namespace Animation
{
    public class SharkAccidents : MonoBehaviour
    {
        [SerializeField] private GameObject sharkPrefab;
        private Animator animator;
        private bool isDead = false;
        private KnobManager knobManager;

        private void Start()
        {
            animator = GetComponent<Animator>();
            knobManager = FindObjectOfType<KnobManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ship") && !isDead)
            {
                animator.SetTrigger("accidentShip");
                isDead = true;
              
                TaskManager.Instance.SetTaskToDone("Ocean Traffic Jam");
                // Vignette
                var position = transform.position;
                AccidentVignette.ShowAccidentVignette(position);
                // Sound
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/SharkShipCrash", position);
            }

            if (other.gameObject.CompareTag("Passenger"))
            {
                
                // Task Done
                TaskManager.Instance.SetTaskToDone("Jaws");

                
                animator.SetTrigger("accidentPassenger");
                Destroy(other.gameObject);
            }
            
            if (other.gameObject.CompareTag("Hook"))
            {
                animator.SetTrigger("accidentPassenger");
            }
        }

        private void SpawnNextShark()
        {
            GameObject sharkInstance = Instantiate(sharkPrefab, transform.position, Quaternion.identity);
            knobManager.interactableObjects.Add(sharkInstance);
        }
    }
}
