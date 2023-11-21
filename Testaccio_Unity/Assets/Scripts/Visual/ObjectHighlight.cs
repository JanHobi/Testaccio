using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectHighlight : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_Scale", 0.99f);
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetFloat("_Scale", 1.05f);
        
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetFloat("_Scale", 0.99f);
    }
}