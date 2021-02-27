using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWall : MonoBehaviour
{
    public CrystalName crystal;

    [SerializeField]
    private MeshRenderer mesh;
    [SerializeField]
    private Light light;

    void Start()
    {
        mesh.material = Global.crystalPrefabs.GetPref(crystal).mat;
        light.color = Global.crystalPrefabs.GetPref(crystal).color;
    }

    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.GetComponent<Bullet>().SetCrystal(crystal);
        }
    }
}
