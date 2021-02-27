using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    [SerializeField]
    private CrystalName id;
    [SerializeField]
    private FireCrystal fireCrystal;
    [SerializeField]
    private Image sprite;

    private void Start()
    {
        //fireCrystal = GameObject.FindGameObjectWithTag("Player").GetComponent<FireCrystal>();
        sprite = this.GetComponent<Image>();
    }

    public void SetCrystal()
    {
        fireCrystal.crystal = id;
        fireCrystal.joy.sprite = sprite.sprite;
        fireCrystal.SetCrystal(id);
    }
}
