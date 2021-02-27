using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mesh;
    [SerializeField]
    private TrailRenderer trail;
    private CrystalPref crystalPref;
    [SerializeField]
    private Rigidbody rb;

    public CrystalName crystal;
    public Transform target;
    public float speed;
    public bool fire, back = false;
    public float liveTime;

    private void OnEnable()
    {
        FireCrystal.GoBack += GoBack;
    }

    private void OnDestroy()
    {
        FireCrystal.GoBack -= GoBack;
    }

    void Start()
    {
        SetCrystal();
    }

    private IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(this.gameObject);
    }

    public void SetCrystal()
    {
        back = false;
        crystalPref = Global.crystalPrefabs.GetPref(crystal);
        mesh.material = crystalPref.mat;
        trail.material = crystalPref.mat;
        Global.dataSave.UseCrystal(crystal, 1);
    }

    public void SetCrystal(CrystalName newCrystal)
    {
        crystal = newCrystal;
        back = false;
        crystalPref = Global.crystalPrefabs.GetPref(crystal);
        mesh.material = crystalPref.mat;
        trail.material = crystalPref.mat;
        Global.dataSave.UseCrystal(crystal, 1);
    }

    void FixedUpdate()
    {
        if (fire)
        {
            if (target != null)
            {
                rb.AddForce(Vector3.Normalize((target.position - this.transform.position)) * speed, ForceMode.Impulse);
                gameObject.transform.forward = target.position - this.transform.position;
            }
            else
            {
                rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            }
        }
    }

    public void StartFire()
    {
        this.transform.SetParent(null);
        fire = true;
        StartCoroutine(WaitToDeath());
    }

    public void Cancel()
    {
        Global.dataSave.TakeCrystal(crystal, 1);
        Destroy(this.gameObject);
    }

    public void GoBack()
    {
        back = true;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Rigidbody>().isKinematic = false;
        StopCoroutine(WaitToDeath());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().Hit(crystal, this);
        }
        if (!back && other.CompareTag("Wall"))
        {
            StopCoroutine(WaitToDeath());
            back = true;
            GetComponent<Rigidbody>().isKinematic = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (back && other.CompareTag("Player"))
        {
            Cancel();
        }
    }
}
