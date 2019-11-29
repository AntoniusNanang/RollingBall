using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{

    public GameObject particle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "")
        {
            Instantiate(particle, transform.position, transform.rotation);
        }
    }

}
