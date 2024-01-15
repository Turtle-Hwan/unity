using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    [SerializeField]
    private float intensity = 5;
    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        target.material.SetColor("_EmissionColor", color * intensity);
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
