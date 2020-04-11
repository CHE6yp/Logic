﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicalInput : MonoBehaviour
{
    public bool value = false;
    public bool Value {
        set
        {
            if (this.value != value)
            {
                this.value = value;
                Debug.Log("Changin!");
                valueChanged?.Invoke(value);
            }
        }
        get
        {
            return value;
        }
    }
    public delegate void LogicalEvent(bool v);
    public event LogicalEvent valueChanged;


    public List<LogicalOutput> sources;

    // Start is called before the first frame update
    void Awake()
    {
        //sources = new List<LogicalOutput>();
    }
    
    void Update()
    {
        if (sources.Any(a => a.value))
        {
            Value = true;
        }
        else
        {
            Value = false;
        }
    }
}