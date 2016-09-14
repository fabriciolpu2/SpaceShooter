using UnityEngine;
using System.Collections;



[System.Serializable]
public class Borda
{
    public float xMin, xMax, zMin, zMax;
}

public class ControleJogador : MonoBehaviour {


    public Rigidbody rb;
    public float velocidade;
    public float inclinacao;
    public Borda borda;
    public GameObject tiro;
    public Transform[] tiroSpawns;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaBt areaButton;

    private AudioSource audioSource;
    private Quaternion calibrarQuarternio;

    // Use this for initialization
    void Start()
    {
        // codigo necessario no unity5
        rb.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        CalibarAcelerometro();
    }

    void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movimento = new Vector3(moveHorizontal, 0.0f, moveVertical);

        /* Acelerometro
        Vector3 aceleracaoRaw = Input.acceleration;
        Vector3 aceleracao = FixAceleracao(aceleracaoRaw);
        Vector3 movimento = new Vector3(aceleracaoRaw.x, 0.0f, aceleracaoRaw.y);
        */
        Vector2 direcao = touchPad.GetDirecao();
        Vector3 movimento = new Vector3(direcao.x, 0.0f, direcao.y);

        rb.velocity = movimento * velocidade;

        rb.position = new Vector3
            (
            Mathf.Clamp (rb.position.x, borda.xMin, borda.xMax), 
            0.0f, 
            Mathf.Clamp(rb.position.z, borda.zMin, borda.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * inclinacao);
    }


    void CalibarAcelerometro ()
    {
        Vector3 aceleracaoSnapshot = Input.acceleration;
        Quaternion rotateQuaternio = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), aceleracaoSnapshot);
        calibrarQuarternio = Quaternion.Inverse(rotateQuaternio);
    }

    Vector3 FixAceleracao (Vector3 aceleracao)
    {
        Vector3 fixedAceleracao = calibrarQuarternio * aceleracao;
        return fixedAceleracao;
    }

    // Update is called once per frame
    private float proxTiro = 0.5f;
    public float fireRate;
	void Update () {
        //if (Input.GetButton("Fire1") && Time.time > proxTiro)
        if (areaButton.CanFire () && Time.time > proxTiro)
        {
            proxTiro = Time.time + fireRate;
            foreach (var tiroSpawn in tiroSpawns)
            {
                Instantiate(tiro, tiroSpawn.position, tiroSpawn.rotation);
            }
            
            audioSource.Play();
        }
	}
}
