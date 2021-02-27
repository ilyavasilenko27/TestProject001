using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject main;
    public CrystalName crystalName;
    public int crystalCount = 2;
    public NavMeshAgent navMesh;
    public Transform target;
    public MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        CrystalPref pref = Global.crystalPrefabs.GetRandom();
        mesh.material = pref.mat;
        crystalName = pref.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            navMesh.destination = target.position;
        }
    }

    public void Hit(CrystalName crystal)
    {
        if (crystal == crystalName)
        {
            Global.dataSave.TakeCrystal(crystal, crystalCount);
            Destroy(main);
        }
        else
        {
            Global.dataSave.UseCrystal(crystalName, crystalCount);
        }

    }

    public void Hit(CrystalName crystal, Bullet bullet)
    {
        bullet.target = null;
        if (crystal == crystalName)
        {
            Global.dataSave.TakeCrystal(crystal, crystalCount);
            Destroy(main);
        }
        else
        {
            Global.dataSave.UseCrystal(crystalName, crystalCount);
        }
    }
}
