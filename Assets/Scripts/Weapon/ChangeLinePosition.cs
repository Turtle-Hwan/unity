using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLinePosition : MonoBehaviour
{
    [SerializeField]
    private int index;
    private LineRenderer target;


    // Start is called before the first frame update
    private void Awake()
    {
        target = GetComponent<LineRenderer>();
    }

    public void Call(Vector3 worldPosition)
    {
        if (target.useWorldSpace)
        {
            target.SetPosition(index, worldPosition);
        }
        else
        {
            Vector3 localPosition = transform.InverseTransformPoint(worldPosition);
            target.SetPosition(index, localPosition);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
