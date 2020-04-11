using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleHandler : LogicalElement
{
    public Module module;

    // Update is called once per frame
    void Update()
    {
        if (Attached())
        {
            if (logicalInput != null)
                module.element.logicalInput.value = logicalInput.value;

            if (logicalOutput != null)
                logicalOutput.value = module.element.logicalOutput.value;
        }
    }

    public bool Attached()
    {
        return module != null;
    }

    public void Attach()
    {

    }

    public void Detach()
    {

    }
}
