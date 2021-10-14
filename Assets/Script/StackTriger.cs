using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTriger : MonoBehaviour
{
    public static StackTriger instance;

    public Dreamteck.Splines.SplineFollower splineFollower;

    public GameObject followerObje;
    public List<GameObject> lastGameObjectsList ;


    private void Awake()
    {
        instance = this;
        splineFollower = followerObje.gameObject.GetComponent<Dreamteck.Splines.SplineFollower>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick")
        {
            StackManager.instance.PickUp(other.gameObject, true,"Untagged");

            lastGameObjectsList.Add(other.gameObject);

            setTag.instance.settag();

            other.transform.localEulerAngles = new Vector3(other.transform.localEulerAngles.x, 0, other.transform.localEulerAngles.z);

            splineFollower.followSpeed += .02f; 
        }
    }
}
