using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    protected bool isInteractable = true;
    protected Outline outline;

    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public bool TryInteract(Transform grabPointTransform)
    {
        if (!isInteractable)
        {
            return false;
        }

        Interact(grabPointTransform);
        return true;
    }

    protected abstract void Interact(Transform grabPointTransform);

    public void EnableOutline()
    {
        if (isInteractable)
        {
            outline.enabled = true;
        }
    }

    public void DisableOutline()
    {
        if (isInteractable)
        {
            outline.enabled = false;
        }
    }
}
