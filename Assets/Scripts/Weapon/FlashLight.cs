using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.05f;
    private Light target;

    // Start is called before the first frame update
    private void Awake()
    {
        target = GetComponent<Light>();
    }

    public void Call()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        target.enabled = true;
        yield return new WaitForSeconds(duration);
        target.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
