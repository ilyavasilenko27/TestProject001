using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Column : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro counter;
    public CrystalName crystalId;
    [SerializeField]
    private Transform crystal;
    private CrystalPref crystalPref;

    void Start()
    {
        crystalPref = Global.crystalPrefabs.GetPref(crystalId);
        Instantiate(crystalPref.pref, crystal.transform);
        counter.text = Global.dataSave.GetValueCrystal(crystalId).ToString();
        counter.color = crystalPref.color;
    }
}
