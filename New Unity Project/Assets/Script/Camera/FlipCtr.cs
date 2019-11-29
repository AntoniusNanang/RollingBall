using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCtr : MonoBehaviour
{
    public Vector3 touchStartPos;
    public Vector3 touchEndPos;
    public string Direction;
    bool oneplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        // xがyより絶対値が大きいとき
        if(Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if(30 < directionX)
            {
                Direction = "right";
            }
            if(-30 > directionX)
            {
                Direction = "left";  
            }
        }
        else if(Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if(30 < directionY)
            {
                Direction = "up";
            }
            if(-30 > directionY)
            {
                Direction = "down";
            }
        }
        else
        {
            Direction = "touch";
        }

        switch (Direction)
        {
            case "up":
                Debug.Log(Direction);
                break;
            case "down":
                Debug.Log(Direction);
                break;
            case "right":
                Debug.Log(Direction);
                break;
            case "left":
                Debug.Log(Direction);
                break;
            case "touch":
                Debug.Log(Direction);
                break;
        }
    }
}
