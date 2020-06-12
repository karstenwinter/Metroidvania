using System;
using UnityEngine;

//namespace UnityStandardAssets.CrossPlatformInput
//{
    public class InputAxisScrollbar : MonoBehaviour
    {
        public string axis;

	    void Update() { }

	    public void HandleInput(float value)
        {
            CrossPlatformInputManager.SetAxis(axis, (value*2f) - 1f);
        }
	    public void HandleInputLeft()
        {
            CrossPlatformInputManager.SetAxis(axis, -1);
        }
	    public void HandleInputRight()
        {
            CrossPlatformInputManager.SetAxis(axis, 1);
        }
	    public void HandleInputNone()
        {
            CrossPlatformInputManager.SetAxis(axis, 0);
        }
    }
//}