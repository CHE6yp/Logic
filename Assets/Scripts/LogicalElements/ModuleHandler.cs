using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class ModuleHandler : LogicalElement
{
    public Module _module;
    public Module module
    {
        set
        {
            if (_module != value)
            {
                _module = value;
                ModuleChanged(value);
                moduleValueChanged?.Invoke(value);
            }
        }
        get
        {
            return _module;
        }
    }
    public delegate void ModuleHandlerEvent(Module m);
    public ModuleHandlerEvent moduleValueChanged;
    public Transform place;
    public ParticleSystem flare;

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

    public void ModuleChanged(Module m)
    {
        if (m)
        {
            flare.Stop();
        }
        else if (logicalInput && logicalInput.value)
        {
            flare.Play();
        }
    }

    public bool Attached()
    {
        return module != null;
    }
}
