using UnityEngine;
using System.Collections;

public class RandonRotation : MonoBehaviour {

    public float rotacao;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotacao;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
