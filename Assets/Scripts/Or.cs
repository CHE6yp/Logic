using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(LogicalOutput))]
public class Or : MonoBehaviour
{
    public List<LogicalInput> logicalInputs;
    public LogicalOutput logicalOutput;

    // Update is called once per frame
    void Update()
    {
        if (logicalInputs.Any(a => a.value))
        {
            logicalOutput.value = true;
        }
        else
        {
            logicalOutput.value = false;
        }
    }
}
