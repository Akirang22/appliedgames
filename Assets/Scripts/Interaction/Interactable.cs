using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool isInteractable = true;

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
}
