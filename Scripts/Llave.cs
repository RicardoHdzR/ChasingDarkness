using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Llave : MonoBehaviour
{
    [SerializeField] Color colorllave;
    [SerializeField] AudioClip keysound,puerta;
    [SerializeField] GameObject black,goodend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sensor")
        {
            Debug.LogWarning("Key found");
            collision.GetComponent<SpriteRenderer>().color = colorllave;
        }
        if (collision.tag == "Player")
        {
	    if (gameObject.name != "Exit")
	    {
            collision.GetComponent<Player>().havekey = true;
		    Destroy(gameObject);
            AudioSource.PlayClipAtPoint(keysound, transform.position);
	    }
            if (gameObject.name == "Exit" && collision.GetComponent<Player>().havekey)
            {
                black.SetActive(true);
                goodend.SetActive(true);
                AudioSource.PlayClipAtPoint(puerta, transform.position);
                Invoke("Goodending", 10f);
                
            }
            
        }
    }
    void Goodending()
    {
        SceneManager.LoadScene("Main menu");
    }
}
