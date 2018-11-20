using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Components;


public class Valve : MonoBehaviour
{
    public string valveTag;

    [SerializeField, Range(0f, 1f)]
    private float _flowRate = 1f;
    public float flowRate
    {
        get { return _flowRate; }
        set { _flowRate = Mathf.Clamp01(value); }
    }

    public AnimationStepper animScrubber;

    Mouledoux.Callback.Packet subPacket = new Mouledoux.Callback.Packet();


    public void Awake()
    {
        if (animScrubber != null) animScrubber.initStartPoint = flowRate;
    }

    private void Start()
    {
        NotifySubs();
    }

    public void AdjustFlowRate(float adjustmentRate)
    {
        flowRate += adjustmentRate * Time.deltaTime;
        NotifySubs();
        if (animScrubber != null) animScrubber.SetAnimationPosition(flowRate);
    }

    private void NotifySubs()
    {
        subPacket.floats = new float[] { flowRate };
        Mediator.instance.NotifySubscribers(valveTag.ToLower() + "->setflow", subPacket);
    }
}
