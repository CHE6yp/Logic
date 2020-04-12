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
    public bool detachable = false;
    public delegate void ModuleHandlerEvent(Module m);
    public ModuleHandlerEvent moduleValueChanged;

    [HideInInspector]
    public Transform place;
    GameObject straps;
    ParticleSystem flare;

    protected override void Awake()
    {
        base.Awake();
        place = transform.Find("Place");
        straps = transform.Find("Visual").Find("Straps").gameObject;
        flare = transform.Find("Visual").Find("Flare").GetComponent<ParticleSystem>();
        straps.SetActive(!detachable);
        
    }

    private void Start()
    {
        FlareToggle();
    }

    //TODO избавиться от апдейта
    protected override void Update()
    {
        
        if (Attached())
        {
            if (logicalInput!=null && module.element.logicalInput != null)
                module.element.logicalInput.value = logicalInput.value;

            if (logicalOutput != null && module.element.logicalOutput != null)
                logicalOutput.value = module.element.logicalOutput.value;
        }
        else
        {
            logicalOutput.value = false;
            
        }
        base.Update();
    }

    public void ModuleChanged(Module m)
    {
        FlareToggle();
    }

    void FlareToggle()
    {
        if (module)
        {
            flare.Stop();
        }
        else if (logicalInput != null && logicalInput.value != null)
        {
            flare.Play();
        }
    }

    public bool Attached()
    {
        return module != null;
    }
}
