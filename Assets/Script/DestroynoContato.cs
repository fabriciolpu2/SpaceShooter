using UnityEngine;
using System.Collections;

public class DestroynoContato : MonoBehaviour
{
    public GameObject explosao;
    public GameObject playerExplosao;
    public int pontosValor;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("nao conseguiu Encontrar GameController script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "Limite")
        if (other.CompareTag("Limite") || other.CompareTag("Inimigo"))
        {
            return;
        }

        if (explosao != null)
        {
            Instantiate(explosao, transform.position, transform.rotation);

        }
       
        if (other.tag == "Player")
        {
            Instantiate(playerExplosao, transform.position, transform.rotation);
            gameController.GameOver(); 
        }

        gameController.AddPonto(pontosValor);
        Destroy(other.gameObject);
        Destroy(gameObject);        
       

    }
}