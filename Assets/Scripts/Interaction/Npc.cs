using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    protected override void Interact(Transform _)
    {
        Talk();
    }

    private void Talk()
    {
        Debug.Log("Hello, I am an NPC character. This should trigger some voicelines!");
        DisableOutline();
        isInteractable = false;
    }
}
