using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class QuickSubscribe : MonoBehaviour
{
    public bool setActive;

    private Mouledoux.Components.Mediator.Subscriptions m_subscriptions =
        new Mouledoux.Components.Mediator.Subscriptions();

    private Mouledoux.Callback.Callback m_subCallback;

    public List<QuickSubscription> m_subs = new List<QuickSubscription>();




    void Awake()
    {
        foreach (QuickSubscription qs in m_subs)
        {
            m_subCallback = qs.InvokeUnityEvent;
            m_subscriptions.Subscribe(qs.m_subMessage, m_subCallback);
        }

        gameObject.SetActive(setActive);
    }


    private void OnDestroy()
    {
        m_subscriptions.UnsubscribeAll();
    }





    [System.Serializable]
    public sealed class QuickSubscription
    {
        public string m_subMessage;
        public UnityEngine.Events.UnityEvent m_event;

        public void InvokeUnityEvent(Mouledoux.Callback.Packet emptyPacket)
        {
            m_event.Invoke();
        }
    }

}