using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crystals")]
public class CrystalPrefabs : ScriptableObject
{
    public List<CrystalPref> crystalPrefs;

    public CrystalPref GetPref(CrystalName name)
    {
        CrystalPref pref = null;
        foreach (CrystalPref crystal in crystalPrefs)
        {
            if (name == crystal.name)
            {
                pref = crystal;
            }
        }
        return pref;
    }

    public CrystalPref GetRandom()
    {
        return crystalPrefs[Random.Range(0, crystalPrefs.Count)];
    }
}

[System.Serializable]
public class CrystalPref
{
    public CrystalName name;
    public GameObject pref;
    public Color color;
    public Material mat;
}

public enum CrystalName
{
    Red, Yellow, Pink, Green
}

