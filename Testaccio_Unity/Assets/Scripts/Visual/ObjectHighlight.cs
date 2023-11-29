using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectHighlight : MonoBehaviour
{
    private Color hoverColor = Color.gray;
    private static Color clickedColor = Color.white;

    private void OnMouseEnter()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        foreach (Material mat in mats)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", hoverColor);
        }

        foreach (Transform child in transform)
        {
            Material[] childMats = child.GetComponent<MeshRenderer>().materials;
            if (childMats.Length == 0) return;
            foreach (Material mat in childMats)
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", hoverColor);
            }
        }

        Time.timeScale = 0.35f;
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

    public static void ChangeToClickedColor(GameObject obj)
    {
        Material[] mats = obj.GetComponent<MeshRenderer>().materials;
        foreach (Material mat in mats)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", clickedColor);
        }

        foreach (Transform child in obj.transform)
        {
            Material[] childMats = child.GetComponent<MeshRenderer>().materials;
            if (childMats.Length == 0) return;
            foreach (Material mat in childMats)
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", clickedColor);
            }
        }
    }

    public static void RemoveClickedColor(GameObject obj)
    {
        Material[] mats = obj.GetComponent<MeshRenderer>().materials;
        foreach (Material mat in mats)
        {
            mat.DisableKeyword("_EMISSION");
        }

        foreach (Transform child in obj.transform)
        {
            Material[] childMats = child.GetComponent<MeshRenderer>().materials;
            if (childMats.Length == 0) return;
            foreach (Material mat in childMats)
            {
                mat.DisableKeyword("_EMISSION");
            }
        }
    }
}