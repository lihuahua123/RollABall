using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
public class EasyTouchTest2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Gesture currentGesture = EasyTouch.current;
        if (currentGesture == null) return;

        if (currentGesture.type == EasyTouch.EvtType.On_TouchStart)
        {
           TouchStart(currentGesture);
        }

        if (currentGesture.type == EasyTouch.EvtType.On_TouchUp)
        {
            TouchEnd(currentGesture);
        }


        if (currentGesture.type == EasyTouch.EvtType.On_Swipe)
        {
            TouchSwip(currentGesture);
        }
    }

    private void TouchStart(Gesture gesture)
    {
        print("OnTouchStart");
        print("StartPosition: " + gesture.startPosition);
    }

    private void TouchEnd(Gesture gesture)
    {
        print("OnTouchEnd");
        print("ActionTime: " + gesture.actionTime);
    }

    private void TouchSwip(Gesture gesture)
    {
        print("OnTouchSwipt");
        print("Swip: " + gesture.swipe);
    }
}
