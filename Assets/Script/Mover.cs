using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float velocidade;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidade;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
