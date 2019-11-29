using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMove : MonoBehaviour
{
    private GameObject m_sphere;
    Rigidbody m_rigidbody;
    public string ObjName;
    // Start is called before the first frame update
    void Start()
    {
        m_sphere = GameObject.Find(ObjName) as GameObject;
        m_rigidbody = m_sphere.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャイロの傾きを取得
        transform.rotation = Input.gyro.attitude;
        //ジャイロから重力の下向きのベクトルを取得。
        //水平に置いた場合はgravity.zが-9.8になる
        Vector3 gravityV = Input.gyro.gravity;
        Vector3 gN = gravityV;
        gN.Normalize();   // 正規化
        float angle = Vector3.Dot(gN, Vector3.back);      // 内積
        float scale = 5.0f;
        Vector3 forceV = new Vector3(gravityV.x, 0.0f, gravityV.y) * scale;
        if (angle < 0.97f)
        {
           m_rigidbody.AddForce(forceV);
        }

        if (Input.touchCount > 0)
        {
            m_sphere.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }

    }
}
