using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCrystal : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private GameObject arrow, arrowImage;
    public Image joy;

    public CrystalName crystal;

    public Hand hand;
    public Sword sword;

    public delegate void Back();
    public static event Back GoBack;


    private void Update()
    {
        Vector3 rot = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (rot != new Vector3(0, 0, 0))
        {
            arrowImage.SetActive(true);
            arrow.transform.forward = rot.normalized;
        }
        if (rot == new Vector3(0, 0, 0))
        {
            arrowImage.SetActive(false);
            arrow.transform.forward = Vector3.forward;
        }
    }

    public void FireUp()
    {
        hand.Fire();
    }

    public void FireDown()
    {
        hand.Spawn();
    }

    public void FireBack()
    {
        GoBack?.Invoke();
    }

    public void SetCrystal(CrystalName crystal)
    {
        sword.crystal = crystal;
        sword.SetCrystal();
    }
}
