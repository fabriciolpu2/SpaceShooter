using UnityEngine;
using System.Collections;

public class DestroyLimite : MonoBehaviour {

	void OnTriggerExit(Collider objeto)
    {
        Destroy(objeto.gameObject);
    }
	    
}
