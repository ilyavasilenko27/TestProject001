using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]
    private Transform model;
    public CrystalName id;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Instantiate(Global.crystalPrefabs.GetPref(id).pref, model.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Take", true);
        }
    }

    public void Destroy()
    {
        Global.dataSave.TakeCrystal(id, 1);
        Destroy(this.gameObject);
    }
}
