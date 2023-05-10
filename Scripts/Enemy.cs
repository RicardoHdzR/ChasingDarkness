using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavPoint nav;
    public GameObject[] navpoints; 
    public GameObject SensorEnemigo;
    public Rigidbody2D cuerpo;
    public GameObject target;
    public float fuerza,velocidad;
    public float tiempo, tiempoo;
    public float stepSize;
    public float cromchdur;
    public AudioClip[] rugido,crunchaudio;
    public AudioClip pisada;
    public AudioSource audiosource;

    [SerializeField] GameObject badending, crunch;

    Vector3 growlpos;
    float croncht;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("movimiento", 0f, fuerza);
        navpoints = GameObject.FindGameObjectsWithTag(nav.tag);
        if (navpoints.Length != 0)
        {
            target = navpoints[Random.Range(1, navpoints.Length - 1)];
            transform.position = target.transform.position;
        }

        growlpos = new Vector3(-100, -100, 0);

    }
    void movimiento()
    {
        if ((target.transform.position - transform.position).magnitude < 0.1f)
        {
            Debug.Log("Cambiando de objetivo");
            target = target.GetComponent<NavPoint>().friends[Random.Range(0, target.GetComponent<NavPoint>().friends.Length)];
            sonar();
        }
        cuerpo.velocity = (target.transform.position - transform.position).normalized*velocidad;
        //Invoke("sonar", fuerza);
        //cuerpo.velocity = new Vector2(Random.Range(-2,2),Random.Range(-2,2)) ;
    }
    void sonar()
    {
        AudioSource.PlayClipAtPoint(pisada, transform.position, 3 / (transform.position - Camera.main.transform.position).magnitude);
	    echo(30, velocidad * fuerza);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            badending.SetActive(true);
            crunch.SetActive(true);
            croncht = Time.time;
            AudioSource.PlayClipAtPoint(crunchaudio[Random.Range(0,2)], transform.position);
            InvokeRepeating("LowOp", 0, 0.1f);
            Invoke("ChangeScene", cromchdur);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LowOp()
    {
        crunch.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1 - (Time.time - croncht)/cromchdur);
    }

    // Update is called once per frame
    void Update()
    {
        if (navpoints.Length == 0) Start();
        movimiento();
        if (target.tag == "Player")
        {
            tiempo += Time.deltaTime;
            velocidad = 4;
            if((growlpos - transform.position).magnitude > stepSize)
            {
                sonar();
                growlpos = transform.position;
            }
            if (tiempo > 5)
            {
                tiempo = 0;
                velocidad = 1;
                float distance = 100f;
                Debug.LogWarning("patrullando");
                foreach (GameObject point in navpoints)
                {
                    Vector3 vector = point.transform.position - transform.position;
                    if (vector.magnitude < distance)
                    {
                        distance = vector.magnitude;
                        target = point;
                    }
                }
            }
        }
        else tiempo = 0;
    }
    private void FixedUpdate()
    {
        tiempoo += Time.deltaTime;
        if (tiempoo > 6)
        {
            tiempoo = 0;
            audiosource.clip = rugido[(int)Random.Range(0, 7)];
            AudioSource.PlayClipAtPoint((AudioClip)audiosource.clip, transform.position, 3 / (transform.position - Camera.main.transform.position).magnitude);
	    echo(120, 3f);
        }
    }
    void echo(int n, float t)
    {
    	for(int i = 0; i < n; i++)
	    {
            Vector3 pos = new Vector3(Mathf.Cos(2 * i * Mathf.PI / n), Mathf.Sin(2 * i * Mathf.PI / n), 0);
            GameObject sensor = Instantiate(SensorEnemigo, transform.position, Quaternion.identity);
            sensor.GetComponent<Rigidbody2D>().velocity = pos * 5;
            sensor.GetComponent<Sensor>().time = t;
	    }
    }
}
