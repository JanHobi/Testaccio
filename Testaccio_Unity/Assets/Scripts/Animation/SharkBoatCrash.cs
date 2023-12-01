using System;
using UnityEngine;

namespace Animation
{
    public class SharkBoatCrash : MonoBehaviour
    {
        [SerializeField] private GameObject ship;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == ship)
            {
               Destroy(gameObject);
            }
        }
    }
}
