using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Destroyable : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bridge"))
        {
            DestroyMe();
            TaskManager.Instance.SetTaskToDone("Heavy Bridge");
        }

    }

    public void DestroyMe() { Destroy(gameObject); }

    public void DestroyMeAfterTime() { Destroy(gameObject, 1); }
}
