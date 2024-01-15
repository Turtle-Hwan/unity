using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVFXColor : MonoBehaviour
{

    [SerializeField]
    private float arrangeRange = 0.5f;
    private ParticleSystem target;
    // Start is called before the first frame update

    private void Awake()
    {
        target = GetComponent<ParticleSystem>();
    }

    public void Call(Color color)
    {
        Color min = color;
        Color max = color * Random.Range(1 - arrangeRange, 1 + arrangeRange);

        ParticleSystem.MainModule module = target.main;
        module.startColor = new ParticleSystem.MinMaxGradient(min, max);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
