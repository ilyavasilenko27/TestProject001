using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private GameObject sword;
    [SerializeField]
    private MeshRenderer mesh;
    [SerializeField]
    private TrailRenderer trail;
    private CrystalPref crystalPref;
    [SerializeField]
    private Rigidbody rb;

    public CrystalName crystal;

    void Start()
    {
        SetCrystal();
    }

    public void SetCrystal()
    {
        crystalPref = Global.crystalPrefabs.GetPref(crystal);
        mesh.material = crystalPref.mat;
        trail.material = crystalPref.mat;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().Hit(crystal);
        }
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            bullet.target = null;
            bullet.crystal = crystal;
            bullet.SetCrystal();
        }
    }
}
