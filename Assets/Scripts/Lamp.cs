using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(Light))]
public class Lamp : MonoBehaviour
{
    public LogicalInput logicalInput;
    public Light light;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logicalInput.value)
            light.intensity = 4;
        else
            light.intensity = 0;
    }
}
