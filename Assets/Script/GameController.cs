using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] asteroids;
    public Vector3 recriarValores;

    public int objPerigoCount;
    public float recriarEsperar;
    public float startEsperar;
    public float waveEspera;

    private int pontuacao;

    public Text scoreText;
    //public Text restartText;
    public Text gameOverText;
    public GameObject restartButton;

    private bool gameOver;
    private bool restartGame;
   
    
    void Start()
    {
        gameOver = false;
        restartGame = false;
        // restartText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";

        pontuacao = 0;
        UpdatePontuacao();
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startEsperar);
        while (true)
        {
            for (int i = 0; i < objPerigoCount; i++)
            {

                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];                
                Vector3 recriarPosicao = new Vector3(Random.Range(-recriarValores.x, recriarValores.x), recriarValores.y, recriarValores.z);
                Quaternion recriarRotacao = Quaternion.identity;
                Instantiate(asteroid, recriarPosicao, recriarRotacao);

                
                yield return new WaitForSeconds(recriarEsperar);
            }
            yield return new WaitForSeconds(waveEspera);
            
            if (gameOver)
            {
                //restartText.text = "Aperte 'R' para Reiniciar!!!";
                restartButton.SetActive(true);
                restartGame = true;
                break;
            }

        }
    }
   

    /// <summary>
    /// 
    /// </summary>
    /// 
    /*
    void Update ()
    {
        if (restartGame)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                 
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    */

    public void RestarGame ()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void AddPonto(int novoPonto)
    {
        pontuacao += novoPonto;
        UpdatePontuacao();
    }

    void UpdatePontuacao()
    {
        scoreText.text = "Pontos: " + pontuacao;
    }

    public void GameOver ()
    {
        gameOverText.text = "Fim de Jogo!!!";
        gameOver = true;
    }
}
