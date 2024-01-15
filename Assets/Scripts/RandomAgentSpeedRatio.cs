using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomAgentSpeedRatio : MonoBehaviour
{
    [SerializeField]
    private float min = 0.8f;
    [SerializeField]
    private float max = 1.5f;
    private NavMeshAgent target;

    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        target.speed *= Random.Range(min, max);
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
