using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionIntensity : MonoBehaviour
{
    [SerializeField]
    private float min = 0;
    [SerializeField]
    private float max = 3;
    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(float ratio)
    {
        float intensity = Mathf.Lerp(min, max, ratio);
        target.material.SetColor("_EmissionColor", target.material.color * intensity);
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
