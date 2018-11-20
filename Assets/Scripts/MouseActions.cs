using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActions : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent
        LeftClick, RightClick,
        LeftHold, RightHold,
        LeftRelease, RightRelease;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) LeftClick.Invoke();

        if (Input.GetMouseButtonDown(1)) RightClick.Invoke();



        if (Input.GetMouseButton(0)) LeftHold.Invoke();

        if (Input.GetMouseButton(1)) RightHold.Invoke();



        if (Input.GetMouseButtonUp(0)) LeftRelease.Invoke();

        if (Input.GetMouseButtonUp(1)) RightRelease.Invoke();
    }
}
