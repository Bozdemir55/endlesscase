using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;

    public Transform prevObject;
    [SerializeField] private Transform parent;
    public Vector3 despos;
    public float distanceBetweenObjects;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.z;
    }
    public void PickUp(GameObject pickedObject, bool needtag = false, string tag = null, bool forwardpickup = true)
    {
        if (needtag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        despos = prevObject.localPosition;
        despos.z += forwardpickup ? distanceBetweenObjects : -distanceBetweenObjects;

        pickedObject.transform.localPosition = despos;

        prevObject = pickedObject.transform;
    }
}
