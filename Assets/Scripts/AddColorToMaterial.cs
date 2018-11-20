using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColorToMaterial : MonoBehaviour
{
    private Material myMaterial;
    private Color myMaterialColor
    {
        get { return new Color(redValue, greenValue, blueValue, alphaValue); }
    }

    [SerializeField, Range(0f, 1f)]
    private float redValue, greenValue, blueValue, alphaValue;

	
	void Start ()
    {
        myMaterial = GetComponent<Renderer>().material;

        redValue = myMaterial.color.r;
        greenValue = myMaterial.color.g;
        blueValue = myMaterial.color.b;
        alphaValue = myMaterial.color.a;
    }
	
	
	void Update ()
    {
        UpdateMaterialColor(Time.deltaTime);
    }


    public void UpdateMaterialColor(float transistionSpeed)
    {
        myMaterial.color = Color.Lerp(myMaterial.color, myMaterialColor, transistionSpeed);
    }

    
    private float AdjustColorValue(ref float color, float adjustment)
    {
       return color += adjustment;
    }
}
