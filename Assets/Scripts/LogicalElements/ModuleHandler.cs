using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleHandler : LogicalElement
{
    public Module module;
    public Transform place;

    // Update is called once per frame
    void Update()
    {
        if (Attached())
        {
            if (logicalInput && module.element.logicalInput)
                module.element.logicalInput.value = logicalInput.value;

            if (logicalOutput && module.element.logicalOutput)
                logicalOutput.value = module.element.logicalOutput.value;
        }
        else
        {
            logicalOutput.value = false;
        }
    }

    public bool Attached()
    {
        return module != null;
    }
}
