using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Bomb : MonoBehaviour
{
    public enum State { Idle, Drop }

    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private LayerMask explosionHittableMask;
    [SerializeField]
    private float recycleDelay = 1;
    [SerializeField]
    private UnityEvent onExplosion;
    [SerializeField]
    private UnityEvent onRecycle;

    private State state;

    public void Drop()
    {
        state = State.Drop;
    }

    public void Throw()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 150, 300));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Idle) return;

        Explosion();
    }

    private void Explosion()
    {
        Collider[] overlaps = Physics.OverlapSphere(transform.position, explosionRadius, explosionHittableMask, QueryTriggerInteraction.Collide);

        foreach (var overlap in overlaps)
        {
            Hittable hitObject = overlap.GetComponent<Hittable>();
            hitObject?.Hit();
        }

        onExplosion?.Invoke();
        Invoke(nameof(Recycle), recycleDelay);

    }

    private void Recycle()
    {
        state = State.Idle;
        onRecycle?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
