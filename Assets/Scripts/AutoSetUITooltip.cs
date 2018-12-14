using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetUITooltip : MonoBehaviour
{
    public GameObject UIPanel;

    private void Awake()
    {
        GetComponent<MouseInteraction>().tooltipUIPanel = UIPanel;
        Destroy(this);
    }
}
