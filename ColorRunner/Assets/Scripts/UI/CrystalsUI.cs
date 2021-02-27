using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI red, pink, yellow, green;

    private void OnEnable()
    {
        DataSave.UpdateUI += UpdateCounters;
    }

    private void OnDisable()
    {
        DataSave.UpdateUI -= UpdateCounters;
    }

    private void Start()
    {
        UpdateCounters();
    }

    private void UpdateCounters()
    {
        red.text = Global.dataSave.GetValueCrystal(CrystalName.Red).ToString();
        pink.text = Global.dataSave.GetValueCrystal(CrystalName.Pink).ToString();
        yellow.text = Global.dataSave.GetValueCrystal(CrystalName.Yellow).ToString();
        green.text = Global.dataSave.GetValueCrystal(CrystalName.Green).ToString();
    }

}
