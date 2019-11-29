using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtr : MonoBehaviour
{
    [SerializeField]
    GameObject m_ball;          // オブジェクトを格納
    [SerializeField]
    Rigidbody m_rid;
    Gyroscope m_gyro;           // 端末

    public GetItem move;
    // Start is called before the first frame update
    void Start()
    {
        m_gyro = Input.gyro;
        m_gyro.enabled = true;          // ジャイロスコープをtrue;
    }

    // Update is called once per frame
    void Update()
    {
        if (move.Is_Move)
        {
            // ジャイロの傾きを取得
            m_ball.transform.rotation = m_gyro.attitude;
            Vector3 gravityVec = m_gyro.gravity;
            float scale = 5.0f;
            Vector3 forceVec = new Vector3(gravityVec.x, 0.0f, gravityVec.y) * scale;
            Vector3 g_Nor = gravityVec;
            g_Nor.Normalize();
            float angle = Vector3.Dot(g_Nor, Vector3.back);
            if (angle < 0.95f)
                m_rid.AddForce(forceVec);

        }

    }
}
