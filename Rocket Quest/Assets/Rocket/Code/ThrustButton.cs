using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrustButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Rocket rocket;

    void Awake()
    {
        rocket = FindObjectOfType<Rocket>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rocket.shouldThrust = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rocket.shouldThrust = false;
    }
}
