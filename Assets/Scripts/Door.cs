using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(LogicalInput))]
public class Door : MonoBehaviour
{
    public LogicalInput logicalInput;
    public Animator animator;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        logicalInput = GetComponent<LogicalInput>();
        logicalInput.valueChanged += Switch;
    }

    public void Switch(bool value)
    {
        Debug.Log("Changed to " + value);
        string trigger = (value) ? "open" : "close";
        animator.SetTrigger(trigger);
        audioSource.Play();
    }
}
