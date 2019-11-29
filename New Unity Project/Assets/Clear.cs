using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public GameObject clear;
    public GameObject tap;
    private AudioSource clear_SE;
    public GameObject Gamebgm;
    public GameObject tap_Title;

    // Start is called before the first frame update
    void Start()
    {
        clear_SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        clear.gameObject.SetActive(true);
        tap.gameObject.SetActive(true);
        Gamebgm.SetActive(false);
        tap_Title.SetActive(true);
        clear_SE.PlayOneShot(clear_SE.clip);
    }

}
