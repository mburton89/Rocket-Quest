using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScrolWheelHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    float initialTouchYPos;
    float currentTouchYPos;
    float initialWheelZRot;
    bool canScroll;
    [SerializeField] Transform wheel;
    [SerializeField] Transform target;

    PointerEventData eventData1;

    public void OnPointerDown(PointerEventData eventData)
    {
        canScroll = true;
        initialTouchYPos = eventData.position.y;
        print(eventData.position.y);
        eventData1 = eventData;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canScroll = false;
        initialWheelZRot = wheel.eulerAngles.z;
    }

    void Update()
    {
        if (canScroll)
        {
            print(eventData1.position);
            currentTouchYPos = eventData1.position.y;
            wheel.eulerAngles = new Vector3(0, 0, initialWheelZRot - (currentTouchYPos - initialTouchYPos));
            target.eulerAngles = wheel.eulerAngles;
        }
    }
}
