using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Module : MonoBehaviour
{
    public LogicalElement element;
    public bool attached = false;

    public void PickUp(Transform player)
    {
        attached = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic= true;
        transform.SetParent(player);
        transform.localPosition= new Vector3(.4f, -.4f, 1);
        transform.localRotation= Quaternion.identity;
    }

    public void Place(Transform moduleHandler)
    {
        if (moduleHandler != null) attached = true;
        transform.SetParent(moduleHandler);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }
}
