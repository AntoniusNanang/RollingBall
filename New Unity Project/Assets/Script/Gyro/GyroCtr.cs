using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCtr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //androidで傾きをの情報を取得する　
        //※これがないと座標の取得ができない
        Input.gyro.enabled = true;

        //ジャイロでの傾きをQuaternionとして取得
        Quaternion q = Input.gyro.attitude;
        Quaternion qq = Quaternion.AngleAxis(90.0f, Vector3.left);
        this.transform.localRotation = qq * q;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
