using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Interfaceler

    [HideInInspector] // deðiþken public olsa da inspector'da gizlemek için kullandým.
    public bool tusaBasildi;
    
    public void OnPointerDown(PointerEventData eventData) // Tuþa basýldý
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData) // Tuþtan el çekildi
    {
        tusaBasildi = false;
    }
}
