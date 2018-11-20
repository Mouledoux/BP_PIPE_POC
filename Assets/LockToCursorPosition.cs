using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToCursorPosition : MonoBehaviour
{
    RectTransform rectTransform;
    UnityEngine.UI.Image myRenderer;

	void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        myRenderer = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        myRenderer.enabled = !Cursor.visible;

		if(Cursor.visible == false)
        {
            rectTransform.position = Input.mousePosition;
        }
	}
}
