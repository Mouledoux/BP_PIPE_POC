using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Color value;

    public bool isOpen;
    public List<Pipe> connectedIntakePipes = new List<Pipe>();

    public bool isFlowing
    {
        get
        {
            if (isOpen == false) return false;
            else if (connectedIntakePipes.Count == 0) return isOpen;


            int flowingConnections = 0;
            Color newValue = new Color();

            foreach (Pipe cp in connectedIntakePipes)
            {
                if (cp.isFlowing)
                {
                    flowingConnections++;
                    newValue += cp.value;
                }
            }

            if (flowingConnections > 0)
            {
                value = Color.Lerp(value, (newValue / flowingConnections), Time.deltaTime);
                return true;
            }


            return false;
        }
    }

	void Start ()
    {
		
	}
	
	void Update ()
    {
        Material mat = GetComponentInChildren<MeshCollider>().GetComponent<Renderer>().material;
        Color matColor = mat.color;
        mat.color = Color.Lerp(matColor, isFlowing ? value : Color.gray, Time.deltaTime);
	}
}
