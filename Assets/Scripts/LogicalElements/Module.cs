using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Module : MonoBehaviour
{
    public LogicalElement element;
    public ModuleHandler handler;
    public bool attached = false;

    private void Awake()
    {
        if (handler) attached = true;
    }

    public void PickUp(Transform player)
    {
        attached = false;
        if (handler)
            handler.module = null;
        handler = null;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic= true;
        transform.SetParent(player);
        transform.localPosition= new Vector3(.4f, -.4f, 1);
        transform.localRotation= Quaternion.identity;
    }

    public void Place(ModuleHandler moduleHandler)
    {
        if (moduleHandler != null)
        {
            attached = true;
            handler = moduleHandler;
            handler.module = this;
        }
        transform.SetParent(moduleHandler.place);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }

    public void Throw()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(transform.forward*300);
        
    }


}
