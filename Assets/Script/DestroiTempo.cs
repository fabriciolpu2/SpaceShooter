using UnityEngine;
using System.Collections;

public class DestroiTempo : MonoBehaviour {

    public float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
