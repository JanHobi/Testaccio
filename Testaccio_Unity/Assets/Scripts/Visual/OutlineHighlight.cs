using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHighlight : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnMouseEnter()
    {
        var outline = gameObject.GetComponent<Outline>();
        outline.OutlineWidth = 6f;
    }

    private void OnMouseExit()
    {
        var outline = gameObject.GetComponent<Outline>();
        outline.OutlineWidth = 0f;
    }
}
