using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP : MonoBehaviour
{
    private int HP;         // プレイヤーHP

    public Text HPText;     // HPをテキスト
    // Start is called before the first frame update
    void Start()
    {
        HP = 9;
        HPText.text = HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damege)
    {
        HP -= damege;
        HPText.text = HP.ToString();
    }
}
