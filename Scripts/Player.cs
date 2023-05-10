using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject SensorPlayer;
    [SerializeField]
    float lastStep;
    public bool havekey = false;
    public float tiempo;
    public AudioClip[] hey,psst,paso;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //InvokeRepeating("InstantiateSensors", 0f, 2f/speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        else
        {
            speed = 3;
        }
        if (rb2d.velocity != new Vector2(0, 0) && Time.time - lastStep > 2f / speed)
        {
            Invoke("Sonar", 0f);
            lastStep = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            tiempo = Time.time;

        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (Time.time - tiempo < 0.5f)
            {
                AudioSource.PlayClipAtPoint(psst[(int)Random.Range(0, 2)], transform.position);
		        echo(90, 0.35f);
            }
            else
            {
                AudioSource.PlayClipAtPoint(hey[(int)Random.Range(0, 2)], transform.position);
		        echo(120, 0.95f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }
    public void Sonar()
    {
        AudioSource.PlayClipAtPoint(paso[(int)Random.Range(0, 2)], transform.position);
	    echo(30, speed * 0.15f);
    }

    public void Pausa()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    void echo(int n, float t)
    {
    	for(int i = 0; i < n; i++)
	{
            Vector3 pos = new Vector3(Mathf.Cos(i * 2 * Mathf.PI / n), Mathf.Sin(i * 2 * Mathf.PI / n), 0);
            GameObject sensor = Instantiate(SensorPlayer, transform.position, Quaternion.identity);
            sensor.GetComponent<Rigidbody2D>().velocity = pos * 5;
            sensor.GetComponent<Sensor>().time = t * speed;
	}
    }


}
