using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractButton : Interactable
{
    [SerializeField]
    private UnityEvent OnClicked;

    protected override void Interact(Transform _)
    {
        OnClicked.Invoke();
    }
}
