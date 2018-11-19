using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public GameObject crate ;
	
	void OnMouseDown()
	{
		crate.GetComponent<MouseInteraction>().ExternalInteractionStart() ;
	}
}
