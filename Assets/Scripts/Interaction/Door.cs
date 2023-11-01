using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Animator anim;

    private bool isOpen = false;

    protected override void Start()
    {
        base.Start();
        anim = GetComponentInParent<Animator>();
    }

    protected override void Interact(Transform _)
    {
        isOpen = !isOpen;
        anim.SetBool("Open", isOpen);
    }
}
