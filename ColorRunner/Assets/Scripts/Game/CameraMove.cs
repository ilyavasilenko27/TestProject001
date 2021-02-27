using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform target;
    private Transform thisCamera;
    private bool find = false;
    [SerializeField]
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = this.gameObject.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
            find = true;
        }
        else
        {
            find = false;
            Debug.Log("Player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (find)
        {
            thisCamera.position = Vector3.Lerp(thisCamera.position, target.position, Time.deltaTime * speed);
        }
    }
}
