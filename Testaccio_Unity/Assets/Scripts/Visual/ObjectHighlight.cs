using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectHighlight : MonoBehaviour
{
    [SerializeField] private Color highlightColor = Color.red;

    private void OnMouseEnter()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        foreach (Material mat in mats)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", highlightColor);
        }

        foreach (Transform child in transform)
        {
            Material[] childMats = child.GetComponent<MeshRenderer>().materials;
            if (childMats.Length == 0) return;
            foreach (Material mat in childMats)
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", highlightColor);
            }
        }

        Time.timeScale = 0f;
    }

    private void OnMouseExit()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        foreach (Material mat in mats)
        {
            mat.DisableKeyword("_EMISSION");
        }

        foreach (Transform child in transform)
        {
            Material[] childMats = child.GetComponent<MeshRenderer>().materials;
            if (childMats.Length == 0) return;
            foreach (Material mat in childMats)
            {
                mat.DisableKeyword("_EMISSION");
            }
        }

        Time.timeScale = 1f;
    }
}