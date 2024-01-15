using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private LayerMask hittableMask;
    [SerializeField]
    private GameObject hitEffectPrefab;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float shootDelay = 0.1f;
    [SerializeField]
    private float maxDistance = 100;
    [SerializeField]
    private UnityEvent<Vector3> onShootSucess;
    [SerializeField]
    private UnityEvent onShootFail;


    private Magazine magazine;

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    private void Start()
    {
        Stop();
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(Process));
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        while (true)
        {
            if (magazine.Use())
            {
                Shoot();
            }
            else
            {
                onShootFail?.Invoke();
            }
            yield return new WaitForSeconds(shootDelay);
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
        {
            Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

            Hittable hitObject = hitInfo.transform.GetComponent<Hittable>();
            hitObject?.Hit();

            onShootSucess?.Invoke(hitInfo.point);
        }
        else
        {
            Vector3 hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            onShootSucess?.Invoke(hitPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
