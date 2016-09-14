using UnityEngine;
using System.Collections;

public class ControleArma : MonoBehaviour {

    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float deley;

    public AudioClip[] clips;

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", deley, fireRate);

	}

    void Fire ()
    {

        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        audioSource.clip = clip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
