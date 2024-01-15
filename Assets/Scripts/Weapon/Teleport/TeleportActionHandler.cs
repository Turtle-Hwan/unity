using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActionHandler : MonoBehaviour
{

    [SerializeField]
    private InputActionReference inputActionRef;
    [SerializeField]
    private UnityEvent onShow;
    [SerializeField]
    private UnityEvent onHide;

    private void OnEnable()
    {
        inputActionRef.action.performed += OnPerformed;
        inputActionRef.action.canceled += OnCanceled;
    }

    private void OnDisable()
    {
        inputActionRef.action.performed -= OnPerformed;
        inputActionRef.action.canceled -= OnCanceled;
    }

    public void OnPerformed(InputAction.CallbackContext obj)
    {
        StartCoroutine(DelayCall(onShow));
    }

    public void OnCanceled(InputAction.CallbackContext obj)
    {
        StartCoroutine(DelayCall(onHide));
    }

    private IEnumerator DelayCall(UnityEvent e)
    {
        yield return null;
        e?.Invoke();
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
