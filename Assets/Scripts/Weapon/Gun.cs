using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGrab;
    [SerializeField]
    private UnityEvent onRelease;

    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;

        if (interactor is XRDirectInteractor)
        {
            onGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;

        if (interactor is XRDirectInteractor)
        {
            onRelease?.Invoke();    
        }
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
