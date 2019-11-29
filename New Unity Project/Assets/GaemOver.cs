using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaemOver : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject tap;
    private AudioSource GameOver_SE;
    public GameObject Gamebgm;
    public GameObject tap_Title;

    void Start()
    {
        GameOver_SE = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOver.gameObject.SetActive(true);
        tap.gameObject.SetActive(true);
        Gamebgm.SetActive(false);
        tap_Title.SetActive(true);
        GameOver_SE.PlayOneShot(GameOver_SE.clip);
        Debug.Log("あたった");
    }

}
