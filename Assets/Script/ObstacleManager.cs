using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private StackTriger _stackTriger;

    public GameObject player;
    public int endpickIndex;
    private GameObject g;
    private void Awake()
    {
        _stackTriger = player.gameObject.GetComponent<StackTriger>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gathered")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            StackManager.instance.despos.z -= StackManager.instance.distanceBetweenObjects;
            other.transform.parent = null;

            endpickIndex = _stackTriger.lastGameObjectsList.Count;
            g = _stackTriger.lastGameObjectsList[endpickIndex - 1];
            endobjethrow();
        }
    }
    public void endobjethrow()
    {
        g.GetComponent<Rigidbody>().isKinematic = false;
        g.GetComponent<Rigidbody>().AddForce(Vector3.back * 12);
        g.GetComponent<rotate>().enabled = true;
        _stackTriger.lastGameObjectsList.Remove(g);
        setTag.instance.settag();
        Invoke("destroyPick", 2f);
    }
    public void destroyPick()
    {

        Destroy(g);
    } 
}
