using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class KnobPlayerInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public bool stopCircling;
   
   private static bool PlayerClick()
   {
       return Input.GetMouseButton(0);
   }
   
   public void OnPointerDown(PointerEventData eventData)
   {
       stopCircling = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       stopCircling = false;
   }
}
