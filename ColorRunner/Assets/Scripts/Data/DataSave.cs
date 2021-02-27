using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Data")]
public class DataSave : ScriptableObject
{
    public int lvl;

    //Crystals
    public List<CrystalSave> crystalSaves;

    public delegate void Crystals();
    public static Crystals UpdateUI;

    public int GetValueCrystal(CrystalName id)
    {
        int res = 0;
        foreach (CrystalSave save in crystalSaves)
        {
            if (save.name == id)
            {
                res = save.value;
            }
        }
        return res;
    }

    public void TakeCrystal(CrystalName id, int add)
    {
        foreach (CrystalSave save in crystalSaves)
        {
            if (save.name == id)
            {
                save.value += add;
                UpdateUI?.Invoke();
            }
        }
        CheckMinCount();
    }

    public void UseCrystal(CrystalName id, int add)
    {
        foreach (CrystalSave save in crystalSaves)
        {
            if (save.name == id)
            {
                save.value -= add;
                UpdateUI?.Invoke();

            }
        }
        CheckMinCount();
    }

    public void CheckMinCount()
    {
        bool death = false;
        foreach (CrystalSave save in crystalSaves)
        {
            if (save.value <= 0)
            {
                death = true;
            }
        }
        if (death)
        {
            Global.buttonManager.Click(ButtonType.Death);
        }
    }

    public void CheckCrystalSave()
    {
        if (crystalSaves.Count != Global.crystalPrefabs.crystalPrefs.Count)
        {
            CreateSaveCrystal();
            Debug.Log("Crystal Save broken, created new");
        }
        else
        {
            Debug.Log("Crystal Save Valid");
        }
        UpdateUI?.Invoke();
    }

    public void CreateSaveCrystal()
    {
        crystalSaves.Clear();
        foreach (CrystalPref crystal in Global.crystalPrefabs.crystalPrefs)
        {
            CrystalSave save = new CrystalSave();
            save.name = crystal.name;
            save.value = 100;
            crystalSaves.Add(save);
        }
    }

    //Save & Load
    public void Save()
    {
        foreach (CrystalSave save in crystalSaves)
        {
            save.Save();
        }
        Debug.Log("Crystals saved");
    }

    public void Load()
    {
        foreach (CrystalSave save in crystalSaves)
        {
            save.Load();
        }
        Debug.Log("Crystals loaded");
    }
}

[System.Serializable]
public class CrystalSave
{
    public CrystalName name;
    public int value;

    public void Save()
    {
        PlayerPrefs.SetInt(name.ToString(), value);
        Debug.Log(name + " Saved: " + value);
    }

    public void Load()
    {
        value = PlayerPrefs.GetInt(name.ToString());
        Debug.Log(name + " Loaded: " + value);
    }
}
