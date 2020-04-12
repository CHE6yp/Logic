using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Door : LogicalElement
{
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Switch(bool value)
    {
        Debug.Log("Changed to " + value);
        string trigger = (value) ? "open" : "close";
        animator.SetTrigger(trigger);
        audioSource.Play();
    }
}
