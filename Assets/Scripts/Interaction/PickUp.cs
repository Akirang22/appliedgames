using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    private Vector3 startPos;
    private Quaternion startRotation;
    private Transform grabPointTransform;
    private Rigidbody rb;
    private IEnumerator coroutine;

    [SerializeField]
    private float lerpSpeed = 10f;
    [SerializeField]
    private float returnToStartDelay = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    protected override void Interact(Transform grabPointTransform)
    {
        if (this.grabPointTransform == null)
        {
            Grab(grabPointTransform);
        } else
        {
            Drop();
        }
       
    }

    private void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        rb.useGravity = false;
        StopCoroutine(coroutine);
    }

    private void Drop()
    {
        grabPointTransform = null;
        rb.useGravity = true;
        coroutine = ReturnToStartState();
        StartCoroutine(coroutine);
    }

    private void FixedUpdate()
    {
        if (grabPointTransform != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPos);
        }
    }

    // Return the object to its original position after a set delay once it is dropped. Grabbing the object
    // once more will stop this coroutine.
    IEnumerator ReturnToStartState()
    {
        yield return new WaitForSeconds(returnToStartDelay);

        transform.position = startPos;
        transform.rotation = startRotation;
    }
}
