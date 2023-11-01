using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSwitch : Interactable
{
    [SerializeField]
    private UnityEvent OnStateOn;
    [SerializeField]
    private UnityEvent OnStateOff;

    [SerializeField]
    private bool isOn;

    protected override void Interact(Transform _)
    {
        isOn = !isOn;

        if (isOn)
        {
            OnStateOn.Invoke();
        } else
        {
            OnStateOff.Invoke();
        }

        // TODO: add switch animation trigger
    }
}
