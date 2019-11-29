using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSE : MonoBehaviour
{
    private AudioSource audioSource_Menu;
    // Start is called before the first frame update
    void Start()
    {
        audioSource_Menu = GetComponent<AudioSource>();
    }

    public void OnClickMenuSE()
    {
        audioSource_Menu.PlayOneShot(audioSource_Menu.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
