using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gaurd : MonoBehaviour {

    public float fOV;
    public float rotSpeed;

    public bool seeing;

    public GameObject player;

    public void Start()
    {
    }
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        Vector3 a = this.transform.forward;
        Vector3 b = player.transform.position - this.transform.position;
        a.Normalize();
        b.Normalize();

        float dot = Vector3.Dot(a, b);

        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fOV))
        {
            if (hit.collider.gameObject == player)
            {
                seeing = true;
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * fOV, Color.green);
        }
    }
}
