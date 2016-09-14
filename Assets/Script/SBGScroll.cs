using UnityEngine;
using System.Collections;

public class SBGScroll : MonoBehaviour {

    public float scrollVelocidade;
    public float tileSizeZ;

    private Vector3 startPosition;
    // Use this for initialization
    void Start () {

        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float novaPosicao = Mathf.Repeat(Time.time * scrollVelocidade, tileSizeZ);
        transform.position = startPosition + Vector3.forward * novaPosicao;

	}
}
