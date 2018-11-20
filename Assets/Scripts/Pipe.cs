using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Components;

public class Pipe : MonoBehaviour
{
    public string valveTag;

    [Space]

    private Material myMaterial;

    private Mediator.Subscriptions subscriptions = new Mediator.Subscriptions();
    public Mouledoux.Callback.Callback adjustFlow;

    [SerializeField]
    private Color _value = Color.white;
    public Color value
    {
        get { return _value * (flowRate = Mathf.Clamp01(flowRate)); }
        set { _value = value; }
    }

    [Range(0f,1f)]
    public float flowRate = 1f;
    public List<Pipe> connectedIntakePipes = new List<Pipe>();

    public bool isFlowing
    {
        get
        {
            if (flowRate <= 0) return false;
            else if (connectedIntakePipes.Count == 0) return flowRate > 0;

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
                newValue /= flowingConnections;
                value = Color.Lerp(_value, newValue, Time.deltaTime);
                return true;
            }


            return false;
        }
    }


    private void Awake()
    {
        if (valveTag == null || valveTag == "") return;

        adjustFlow = SetFlowRate;
        subscriptions.Subscribe(valveTag.ToLower() + "->setflow", adjustFlow);
    }

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Color newColor = (isFlowing ? value : Color.white);
        newColor.a = 1f;
        myMaterial.color = Color.Lerp(myMaterial.color, newColor, Time.deltaTime);
    }

    private void OnDestroy()
    {
        subscriptions.UnsubscribeAll();
    }


    public void SetFlowRate(float newFlow)
    {
        flowRate = newFlow;
    }

    public void SetFlowRate(Mouledoux.Callback.Packet packet)
    {
        SetFlowRate(packet.floats[0]);
    }
}