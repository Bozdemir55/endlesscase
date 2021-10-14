using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchMouseManager : MonoBehaviour
{
    public bool right;
    public bool left;

    float speed = 5f;

    public GameObject parentCube;
    // Update is called once per frame
    void Update()
    {
        Vector3 right_move = new Vector3(.02f, 0.076f, transform.localPosition.z);
        Vector3 left_move = new Vector3(-.02f, 0.076f, transform.localPosition.z);
       
        
        if (Input.touchCount >0)
        {
            Touch finger = Input.GetTouch(0);


            if (finger.deltaPosition.x > 50f)
            {
                right = true;
                left = false;
            }
            if (finger.deltaPosition.x < -50f)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                transform.localPosition += right_move;
                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -1.2f, 1.2f), Mathf.Clamp(transform.localPosition.y, -.2f, .2f), transform.localPosition.z);
            }
            if (left == true)
            {
                transform.localPosition += left_move;
                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -1.2f, 1.2f), Mathf.Clamp(transform.localPosition.y, -.2f, .2f), transform.localPosition.z);
            }
            
        }
        else
        {            
            transform.position = Vector3.MoveTowards(transform.position, parentCube.transform.position, Time.deltaTime * speed * 12f);
            right = false;
            right = false;
        }

    }
}
