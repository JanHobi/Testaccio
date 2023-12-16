using Managers;
using UnityEngine;

namespace Animation
{
    public class Destroyable : MonoBehaviour
    {    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bridge"))
            {
                TaskManager.Instance.SetTaskToDone("Heavy Bridge");
            }

        }

        public void DestroyMe() { Destroy(gameObject); }

        public void DestroyMeAfterTime() { Destroy(gameObject, 1); }
    }
}
