using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestinationToCore : MonoBehaviour
{
    private NavMeshAgent target;

    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();  
    }

    public void Call()
    {
        target.SetDestination(Core.Instance.transform.position);
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
