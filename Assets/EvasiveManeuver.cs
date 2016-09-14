﻿using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    private Rigidbody rb;
    private float targetManeuver;    
    private float currentSpeed;
    public float tilt;

    public float dodge;
    public float smoothing;

    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    private Transform playerTransform;
    

    public Borda borda;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade ()
    {

        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {


            //targetManeuver = Random.Range(1 , dodge) *  -Mathf.Sign(transform.position.x);

            targetManeuver = playerTransform.position.x;
            yield return new WaitForSeconds(Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range (maneuverWait.x, maneuverWait.y));
        }

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, borda.xMin, borda.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, borda.zMin, borda.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
