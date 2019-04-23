using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
public class EasyTouchTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        EasyTouch.On_TouchStart += TouchStart;
        EasyTouch.On_TouchUp += TouchEnd;
        EasyTouch.On_Swipe += TouchSwip;
	}

    private void OnDisable()
    {
        EasyTouch.On_TouchStart -= TouchStart;
        EasyTouch.On_TouchUp -= TouchEnd;
        EasyTouch.On_Swipe -= TouchSwip;
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
