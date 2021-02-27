using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMap : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Global.buttonManager.Click(ButtonType.Death);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
