using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public CrystalPrefabs crystalPrefabs;
    public DataSave dataSave;
    public ButtonManager buttonManager;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        Global.crystalPrefabs = crystalPrefabs;
        Global.dataSave = dataSave;
        Global.buttonManager = buttonManager;
        Global.dataSave.CheckCrystalSave();
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == Scenes.Game.ToString())
        {
            Debug.Log("Game loaded");
        }
    }

}
