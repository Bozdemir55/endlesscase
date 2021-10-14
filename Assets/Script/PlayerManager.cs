using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float maxDintance = 3;
    public GameObject parentCube;
    public float xDirection;
    public float speed;
    public Vector3 moveDirection;
    public Vector3 xDirectionEulerAngles;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        speed = .1f;
        xDirection = Input.GetAxis("Horizontal");

        if (xDirection==0)
        {
            xDirection = Mathf.MoveTowards(xDirection, 0, Time.deltaTime*10f);
            xDirectionEulerAngles = Vector3.MoveTowards(xDirectionEulerAngles, parentCube.transform.localEulerAngles, Time.deltaTime * speed * 2f);
            transform.position = Vector3.MoveTowards(transform.position, parentCube.transform.position , Time.deltaTime * speed*2f);

        }
        else
        {
            if (xDirection>0)
            {
                moveDirection = new Vector3(xDirection, xDirection / 8, 0f);
                transform.localEulerAngles = new Vector3(0, 0, xDirection * 38f);

            }
            else
            {

                moveDirection = new Vector3(xDirection, -xDirection / 4, 0f);
                transform.localEulerAngles = new Vector3(0, 0, xDirection * 38f);
            }     
        }
        moveDirection.x = Mathf.Clamp(moveDirection.x, -1, 1);

        transform.localPosition += moveDirection * speed;


    }

}
