using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager2 : MonoBehaviour
{
    float maxDintance = 3;
    public GameObject parentCube;
    public float xDirection;
    //public float speed;
    public Vector3 moveDirection;
    public Vector3 xDirectionEulerAngles;



    [Header("Movement")]
    [SerializeField] private float speed;



    private float mZCoord;
    private Vector3 mOffset;

    private void Start()
    {

    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //    mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        //    Debug.Log(mOffset);
        //    Debug.Log(GetMouseAsWorldPoint().x);
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    if (mOffset.x < 0)
        //    {
        //        Vector3 andPos = new Vector3((GetMouseAsWorldPoint().x + mOffset.x), transform.position.y + (mOffset.x) / 8, transform.position.z);

        //        transform.position = Vector3.Lerp(transform.position, andPos, speed * Time.deltaTime);
        //        transform.localEulerAngles = new Vector3(0, 0, mOffset.x * 38f);
        //    }
        //    if (mOffset.x > 0)
        //    {
        //        Vector3 andPos = new Vector3((GetMouseAsWorldPoint().x - mOffset.x), transform.position.y + (mOffset.x) / 8, transform.position.z);

        //        transform.position = Vector3.Lerp(transform.position, andPos, speed * Time.deltaTime);
        //        transform.localEulerAngles = new Vector3(0, 0, mOffset.x * 38f);
        //    }


        //    //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -33.8f, 33.8f), transform.position.y, transform.position.z); // platformun sağ ve sol sınırını belirle 

        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    xDirection = Mathf.MoveTowards(xDirection, 0, Time.deltaTime*10f);
        //    xDirectionEulerAngles = Vector3.MoveTowards(xDirectionEulerAngles, parentCube.transform.localEulerAngles, Time.deltaTime * speed * 2f);
        //    transform.position = Vector3.MoveTowards(transform.position, parentCube.transform.position , Time.deltaTime * speed*2f);

        //}

        speed = .1f;

        if (Input.GetMouseButtonUp(0))
        {
            xDirection = Mathf.MoveTowards(xDirection, 0, Time.deltaTime * 10f);
            xDirectionEulerAngles = Vector3.MoveTowards(xDirectionEulerAngles, parentCube.transform.localEulerAngles, Time.deltaTime * speed * 12f);
            transform.position = Vector3.MoveTowards(transform.position, parentCube.transform.position, Time.deltaTime * speed * 12f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            xDirection = gameObject.transform.position.x - GetMouseAsWorldPoint().x;

        }
        if (Input.GetMouseButton(0))
        {

                if (xDirection > 0)
                {
                    moveDirection = new Vector3(xDirection, xDirection / 8, 0f);
                    transform.localEulerAngles = new Vector3(0, 0, xDirection * 88f);

                }
                else
                {

                    moveDirection = new Vector3(xDirection, -xDirection / 4, 0f);
                    transform.localEulerAngles = new Vector3(0, 0, xDirection * 88f);
                }

            transform.localPosition += moveDirection * speed;

        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {

        Vector3 mousePoint = Input.mousePosition;


        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}