using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSE : MonoBehaviour
{

    private AudioSource soundTitle;

    // Start is called before the first frame update
    void Start()
    {
        soundTitle = GetComponent<AudioSource>();
    }

    public void OnClickTitleSE()
    {
        soundTitle.PlayOneShot(soundTitle.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
