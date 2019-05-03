using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {
    //GunController gunScript;
    GameObject shot;
    GameObject gun;
    private Rigidbody2D rb;
    [SerializeField] private float powerFactor;
    GameObject main;
    [SerializeField] private float offset;

    void Start () {
        shot = GameObject.Find("Shot");
        gun = GameObject.Find("Gun");
        main = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = gun.transform.up * GunController.power * powerFactor; 
	}
	
	void Update () {
        main.transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z - 10);
    }
}
