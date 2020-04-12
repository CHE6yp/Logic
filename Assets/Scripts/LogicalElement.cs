using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalElement : MonoBehaviour, IOneOutput
{
    //public IOneOutput inputElement;
    public GameObject _inputElement; //bad
    public GameObject inputElement
    {
        set
        {
            if (_inputElement != value)
            {
                _inputElement = value;

                SetNewInputElement();
                //ModuleChanged(value);
                //moduleValueChanged?.Invoke(value);
            }
        }
        get
        {
            return _inputElement;
        }
    }

    public LogicalInput logicalInput;
    public LogicalOutput _logicalOutput;
    public LogicalOutput logicalOutput {
        get { return _logicalOutput; }
        set { _logicalOutput = value; }
    }

    protected virtual void Awake()
    {
        SetNewInputElement();
    }

    void SetNewInputElement()
    {
        if (inputElement != null)
        {
            logicalInput.source = (inputElement.GetComponent(typeof(IOneOutput)) as IOneOutput).logicalOutput; //veryBad, but can't expose interface field in inspector otherwise
        }
    }
}
