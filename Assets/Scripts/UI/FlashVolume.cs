using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlashVolume : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.05f;
    private Volume target;

    private void Awake()
    {
        target = GetComponent<Volume>();
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
