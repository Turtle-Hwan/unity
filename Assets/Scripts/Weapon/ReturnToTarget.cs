using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnToTarget : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float duration = 1;
    [SerializeField]
    private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField]
    private UnityEvent onCompleted;

    public void Call()
    {
        if (!gameObject.activeInHierarchy) return;

        StopAllCoroutines();
        StartCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        if (target == null) yield break;

        float beginTime = Time.time;

        while (true)
        {
            float t = (Time.time - beginTime) / duration;

            if (t >= 1) break;

            t = curve.Evaluate(t);

            transform.position = Vector3.Lerp(transform.position , target.position, t);

            yield return null;
        }

        transform.position = target.position;

        onCompleted?.Invoke();
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
