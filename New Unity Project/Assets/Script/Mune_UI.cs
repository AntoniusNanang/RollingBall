using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mune_UI : MonoBehaviour
{
    [SerializeField] private GameObject Window;
    [SerializeField] private GameObject windowbutton;
    [SerializeField] private GameObject Titlebutton;
    [SerializeField] private GameObject Stegeselectbutton;
    [SerializeField] private GameObject Setumeibutton; 
    [SerializeField] private float startpos;
    [SerializeField] private float endpos;
    [SerializeField] private float SPEED=3f;

    private float nowpos;

    private bool movedecision = true;
    private bool windowtrigger = false;
    private RectTransform window;


    // Start is called before the first frame update
    void Start()
    {
        window = Window.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        nowpos = window.localPosition.y;

        if(movedecision && windowtrigger)
        {
            if (nowpos > startpos)
            {
                window.localPosition -= new Vector3(0, SPEED, 0);
            }
            else if (nowpos <= startpos)
            {
                windowtrigger = false;
                movedecision = false;
            }
        }
        else if (windowtrigger)
        {
            if (nowpos < endpos)
            {
                window.localPosition += new Vector3(0, SPEED, 0);
            }
            if (nowpos >= endpos)
            {
                windowtrigger = false;
                movedecision = true;
            }
        }
    }

    public void OnClickWindowButton()
    {
        Debug.Log("押された");
        windowtrigger = true;
    }

    public void OnClickTitleButton()
    {
        Debug.Log("タイトル");
    }
    public void OnClickStegeselectButton()
    {
        Debug.Log("ステージセレクト");
    }
    public void OnClickSetumeiButton()
    {
        Debug.Log("説明");
    }
}
