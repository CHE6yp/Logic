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
                ChangeModule(value);
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

        ChangeModule(module);
        logicalInput.valueChanged += FlareToggle;

    }

    private void Start()
    {
        FlareToggle(logicalInput.value);
    }


    public void ChangeModule(Module newModule)
    {
        if (_module != null)
        {
            logicalInput.valueChanged -= UpdateInput;
            _module.element.logicalOutput.valueChanged -= UpdateOutput;
            _module.element.logicalInput.value = false;//В отсоединеный модуль не идет ток, потому всегда фолс
        }
        _module = newModule;
        if (_module != null)
        {
            logicalInput.valueChanged += UpdateInput;
            _module.element.logicalOutput.valueChanged += UpdateOutput;
        }
        UpdateInput();
        UpdateOutput();
        FlareToggle(logicalInput.value);
    }

    void FlareToggle(bool v)
    {
        if (v && module==null)
        {
            flare.Play();
        }
        else
        {
            flare.Stop();
        }
    }

    public bool Attached()
    {
        return module != null;
    }


    void UpdateInput()
    {
        if (Attached())
            module.element.logicalInput.value = logicalInput.value;
    }

    void UpdateOutput()
    {
        logicalOutput.value = (Attached())? module.element.logicalOutput.value : false;
    }

    void UpdateInput(bool v)
    {
        module.element.logicalInput.value = v;
    }

    void UpdateOutput(bool v)
    {
        logicalOutput.value = v;
    }
}
