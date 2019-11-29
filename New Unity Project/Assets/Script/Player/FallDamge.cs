using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamge : MonoBehaviour
{

    // レイを飛ばす場所
    [SerializeField]
    private Transform rayPosition;
    // レイを飛ばす距離
    [SerializeField]
    private float rayRange = 0.85f;
    // 落ちた場所
    private float fallenPos;
    [SerializeField]
    // HP処理スクリプト
    private MyHP myHP;
    // 落ちた地点を設定したかどうか
    private bool isFall;
    // 落下してから地面に落ちるまでの距離
    private float fallenDis;
    // どのくらいの高さからダメージを与えるか
    [SerializeField]
    private float takeDamegeDis = 2;
    // Start is called before the first frame update
    void Start()
    {
        fallenDis = 0;
        fallenPos = transform.position.y;
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        // レイを見る処理
        Debug.DrawLine(rayPosition.position, rayPosition.position + Vector3.back * rayRange, Color.blue);

        // 落ちてる状態
        if (isFall)
        {
            // 落下地点と現在地点の距離を測る
            fallenPos = Mathf.Max(fallenPos, transform.position.y);

            // 地面にレイが届いたら
            if (Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Field")))
            {
                // 落下距離を計算
                fallenDis = fallenPos - transform.position.y;
                // 落下にとるダメージが発生する距離を超える場合ダメージを与える
                if (fallenDis >= takeDamegeDis)
                {
                    if ((int)(fallenDis) >= 3 && (int)(fallenDis) < 6)
                        myHP.TakeDamage(3);
                    if ((int)(fallenDis) >= 6 && (int)(fallenDis) < 8)
                        myHP.TakeDamage(6);
                    if ((int)(fallenDis) >= 8)
                        myHP.TakeDamage(9);
                }
                isFall = false;
            }
        }
        else
        {
            // 地面にレイが届いていなければ落下地点を設定
            if (!Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Field", "Blocks")))
            {
                // 最初の落下地点を設定
                fallenPos = transform.position.y;
                fallenDis = 0;
                isFall = true;
            }
        }
    }

}
