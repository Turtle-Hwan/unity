using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{

    [SerializeField]
    private UnityEvent<Color> onCreated;

    [SerializeField]
    private float hueMin = 0;
    [SerializeField]
    private float hueMax = 1;
    [SerializeField]
    private float saturationMin = 0.7f;
    [SerializeField]
    private float saturationMax = 1;
    [SerializeField]
    private float valueMin = 0.7f;
    [SerializeField]
    private float valueMax = 1;

    public void Call()
    {
        Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
        onCreated.Invoke(color);
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
