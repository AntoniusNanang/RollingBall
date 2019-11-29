using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ItemObj;
    int count;          // アイテムを何個集めたか
    int MaxCount;       // 最大アイテム
    Vector3[] v2 = new Vector3[2];
    public GameObject Clear;
    public GameObject tap;
    public AudioSource clear_SE;
    public GameObject Gamebgm;
    public GameObject tap_Title;
    public bool Is_Move = true;


    // Start is called before the first frame update
    void Start()
    {
        Is_Move = true;
        count = 0;
        MaxCount = 2;
        clear_SE = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(count >= MaxCount)
        {
            gameObject.SetActive(false);
            Debug.Log("クリア");
            Clear.SetActive(true);
            count = 0;
            tap.gameObject.SetActive(true);
            Gamebgm.SetActive(false);
            tap_Title.SetActive(true);
            clear_SE.PlayOneShot(clear_SE.clip);
        }
    }

    private void ItemTake()
    {
        Vector3 v1 = transform.position;
        Vector3[] dir =new Vector3[2];
        v2[0] = ItemObj[0].transform.position; v2[1] = ItemObj[1].transform.position;
        dir[0] = v1 - v2[0]; dir[1] = v1 - v2[1];
        float[] d = new float[2];
        d[0] = dir[0].magnitude; d[1] = dir[1].magnitude;
        float r1 = 0.5f;
        float r2 = 0.2f;
        if (r1+r2 > d[0])
        {
            count += 1;
            Destroy(ItemObj[0]);
            Debug.Log(count);
        }
        if(r1 + r2 > d[1])
        {
            count += 1;
            Destroy(ItemObj[1]);
            d[1] = 100;
            Debug.Log(count);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if(layerName == "Item")
        {
            Destroy(other.gameObject);
            count++;
        }
    }
}
