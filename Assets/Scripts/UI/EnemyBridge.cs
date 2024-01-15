using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBridge : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCall;

    public void Call()
    {
        onCall?.Invoke();
    }
}
