using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private Transform grabPointTransform;

    [SerializeField]
    private float interactionDistance = 5f;

    private Camera CameraMain;
    [SerializeField]
    private Interactable previousInteractable;

    private void Start()
    {
        CameraMain = Camera.main;
    }

    void Update()
    {
        if (Physics.Raycast(CameraMain.transform.position, CameraMain.transform.forward, out RaycastHit hit, interactionDistance))
        {
            if (!hit.transform.TryGetComponent(out Interactable interactable))
            {
                if (previousInteractable != null)
                {
                    previousInteractable.DisableOutline();
                }
                previousInteractable = null;
                return;
            }

            if (previousInteractable != interactable)
            {
                if (previousInteractable != null)
                {
                    previousInteractable.DisableOutline();
                }
                interactable.EnableOutline();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.TryInteract(grabPointTransform);
            }

            previousInteractable = interactable;
        } else
        {
            if (previousInteractable != null)
            {
                previousInteractable.DisableOutline();
            }
            previousInteractable = null;
        }
    }
}
