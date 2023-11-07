using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTextBehaviour : MonoBehaviour
{
    private TextMeshProUGUI buttonText;

    private void Start()
    {
        buttonText = GetComponent<TextMeshProUGUI>();
    }

    public void SelectButton()
    {
        buttonText.text = "<u>" + buttonText.text + "</u>";

    }

    public void DeselectButton()
    {
        buttonText.text = buttonText.text.Replace("<u>", "");
        buttonText.text = buttonText.text.Replace("</u>", "");
    }

    public void ClickButton()
    {
        buttonText.text = "<mark=#46FF00>" + buttonText.text + "</mark>";
    }
}
