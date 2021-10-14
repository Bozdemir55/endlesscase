using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTag : MonoBehaviour
{
    public static setTag instance;

    public GameObject prevcubeobject;
    public void Awake()
    {
        instance = this;
    }
    void Update()
    {

    }
    public void settag()
    {
        if (StackTriger.instance.lastGameObjectsList.Count<= 0)
        {
            return; 
        }
        foreach (var item in StackTriger.instance.lastGameObjectsList)
        {
            item.tag = "Untagged";

        }
        StackTriger.instance.lastGameObjectsList[StackTriger.instance.lastGameObjectsList.Count - 1].transform.tag = "gathered";
        if (StackTriger.instance.lastGameObjectsList.Count >= 2)
        {
            StackManager.instance.prevObject = StackTriger.instance.lastGameObjectsList[StackTriger.instance.lastGameObjectsList.Count - 1].transform;
        }
        else
        {
            StackManager.instance.prevObject = prevcubeobject.transform;
        }

    }
}
