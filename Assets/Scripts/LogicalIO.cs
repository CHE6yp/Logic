using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalIO : MonoBehaviour
{
    public bool _value = false;
    public bool value
    {
        set
        {
            if (_value != value)
            {
                _value = value;
                valueChanged?.Invoke(value);
            }
        }
        get
        {
            return _value;
        }
    }
    public delegate void LogicalEvent(bool v);
    public event LogicalEvent valueChanged;
}
