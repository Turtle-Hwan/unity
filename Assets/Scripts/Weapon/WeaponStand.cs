using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponStand : MonoBehaviour
{
    public void OnSocketed(SelectEnterEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StartReload();
    }

    public void OnUnsocketed(SelectExitEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StopReload();
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
