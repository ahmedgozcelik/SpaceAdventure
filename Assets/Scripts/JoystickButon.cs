using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Interfaceler

    [HideInInspector] // de�i�ken public olsa da inspector'da gizlemek i�in kulland�m.
    public bool tusaBasildi;
    
    public void OnPointerDown(PointerEventData eventData) // Tu�a bas�ld�
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData) // Tu�tan el �ekildi
    {
        tusaBasildi = false;
    }
}
