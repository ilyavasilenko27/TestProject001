using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject bulletObj;
    [SerializeField]
    private GameObject bulletPref;
    private bool bulletEnable = false;
    [SerializeField]
    private Collider area;
    [SerializeField]
    private List<GameObject> targets;

    public void Spawn()
    {
        area.enabled = true;
    }

    public void Fire()
    {
        area.enabled = false;
        foreach (GameObject gameObject in targets)
        {
            if (!bulletEnable)
            {
                CrystalName crystal = gameObject.GetComponent<EnemyScript>().crystalName;
                bulletObj = bulletPref;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                bullet.target = gameObject.transform;
                bullet.crystal = crystal;
                bullet.fire = false;
                bulletObj = Instantiate(bulletObj, this.transform.position, this.transform.rotation, this.transform);

                bulletEnable = true;
            }
            if (bulletEnable)
            {
                if (bulletObj != null)
                {
                    bulletObj.GetComponent<Bullet>().StartFire();
                }


                bulletObj = null;
                bulletEnable = false;
            }
        }
        targets.Clear();
    }

    public void Reset()
    {
        if (bulletEnable)
        {
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.Cancel();
            //Destroy(bulletObj);
            bulletEnable = false;
            area.enabled = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (targets.Count <= 0)
            {
                targets.Add(other.gameObject);
            }
            else
            {
                bool find = false;
                foreach (GameObject gameObject in targets)
                {
                    if (other.gameObject == gameObject)
                    {
                        find = true;
                    }
                }
                if (!find)
                {
                    targets.Add(other.gameObject);
                }
            }
        }
    }
}
