using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtr : MonoBehaviour
{
    public GameObject TargetObj;
    public Vector3[] Pos;


    private int r, l, d, f, x;
    public float speed = 10.0f;
    private float timecnt;
    private float NowVec = 0.0f;
    private bool[] CameraMove_Flag;
    private bool[] ButtonFlag;
    private bool cameraPart2 = false;
    private int n = 0;

    Quaternion quaternion;
    float camera_y;

    // Start is called before the first frame update
    void Start()
    {
        //quaternion = transform.rotation;
        //camera_y = -90.0f;

        // カメラフラグの初期化
        CameraMove_Flag = new bool[7];
        CameraMove_Flag[0] = false; CameraMove_Flag[1] = false; CameraMove_Flag[2] = false; CameraMove_Flag[3] = false;
        CameraMove_Flag[4] = false; CameraMove_Flag[5] = false; CameraMove_Flag[6] = false;

        // ボタンフラグの初期化
        ButtonFlag = new bool[2];
        ButtonFlag[0] = true; ButtonFlag[1] = false;

        r = 1; l = 3; d = 0; f = 2; x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(TargetObj.transform);
        if (ButtonFlag[0]) ButtonCtr();
        CameraMove();
    }

    // 球面線形補間
    Vector3 CameraMove(Vector3 startVec, Vector3 endVec, ref float n)
    {
        float dis = Vector3.Distance(startVec, endVec);
        timecnt += Time.deltaTime;
        n = (timecnt * speed) / dis;
        return transform.position = Vector3.Slerp(startVec, endVec, n);
    }

    void ButtonCtr()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) CameraMove_Flag[0] = true;
        if (Input.GetKeyDown(KeyCode.LeftArrow))  CameraMove_Flag[1] = true;
        if (Input.GetKeyDown(KeyCode.UpArrow))    CameraMove_Flag[2] = true; 
        if (Input.GetKeyDown(KeyCode.DownArrow))  CameraMove_Flag[3] = true; 
    }

    void CameraMove()
    {
        if (CameraMove_Flag[0])
        {
            ButtonFlag[0] = false;
            CameraMove(Pos[x], Pos[r], ref NowVec);
            if (NowVec >= 1.0f)
            {
               
                timecnt = 0;
                CameraMove_Flag[0] = false;
                ButtonFlag[0] = true;
                r += 1;
                if (r > 3) r = 0;
                d += 1;
                if (d > 3) d = 0;
                l += 1;
                if (l > 3) l = 0;
                f += 1;
                if (f > 3) f = 0;
                if (x >= 4) x = d;
                else x += 1;
                if (x > 3) x = 0;
                cameraPart2 = false;
            }
        }
        if (CameraMove_Flag[1])
        {

            ButtonFlag[0] = false;
            CameraMove(Pos[x], Pos[l], ref NowVec);
            if (NowVec >= 1.0f)
            {
                
                timecnt = 0;
                CameraMove_Flag[1] = false;
                ButtonFlag[0] = true;
                r -= 1;
                if (r < 0) r = 3;
                d -= 1;
                if (d < 0) d = 3;
                l -= 1;
                if (l < 0) l = 3;
                f -= 1;
                if (f < 0) f = 3;
                if (x >= 4) x = d;
                else x -= 1;
                if (x < 0) x = 3;
                cameraPart2 = false;
            }
        }
        if (CameraMove_Flag[2])
        {
            ButtonFlag[0] = false;
            if (!cameraPart2)
            {
                CameraMove(Pos[x], Pos[4], ref NowVec);            
                if (NowVec >= 1.0f)
                {
                    timecnt = 0;
                    CameraMove_Flag[2] = false;
                    ButtonFlag[0] = true;
                    x = 4;
                    cameraPart2 = true;
                }
            }
            if (cameraPart2)
            {
                CameraMove(Pos[x], Pos[f], ref NowVec);
                if (NowVec >= 1.0f && cameraPart2)
                {
                    timecnt = 0;
                    CameraMove_Flag[2] = false;
                    ButtonFlag[0] = true;
                    x = f;
                    r += 2;
                    if (r > 3) r = 0;
                    d += 2;
                    if (d > 3) d = 0;
                    l += 2;
                    if (l > 3) l = 0;
                    f += 2;
                    if (f > 3) f = 0;
                    cameraPart2 = false;
                }
            }
            
        }
        if (CameraMove_Flag[3])
        {
            if (cameraPart2)
            {
                ButtonFlag[0] = true;
                CameraMove(Pos[x], Pos[d], ref NowVec);
                if(NowVec >= 1.0f)
                {
                    timecnt = 0;
                    CameraMove_Flag[3] = false;
                    ButtonFlag[0] = true;
                    x = d;
                    cameraPart2 = false;
                }
            }
        }
    }
}
