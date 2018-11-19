using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	private Light myLight ;
	private Material myMaterial ;
	private Color lightOffColor ;
	public Color lightOnColor ;

	void Start() {

		myLight = GetComponentInChildren<Light>() ;
		myMaterial = GetComponent<Renderer>().material ;
		lightOffColor = myMaterial.GetColor("_EmissionColor") ;

	}

	public void LightToggle(bool _state) {

		myLight.intensity = _state ? 1f : 0f ;
		Color newColor = _state ? lightOnColor : lightOffColor ;
		myMaterial.SetColor("_EmissionColor", newColor) ;

	}
}
