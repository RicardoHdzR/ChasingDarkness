using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject test;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.tag == "sensor")
        {
            enemy.GetComponent<Enemy>().target = test;
            //Debug.LogError(-collision.gameObject.GetComponent<Rigidbody2D>().velocity * 10);
            //test.transform.position = (-collision.gameObject.GetComponent<Rigidbody2D>().velocity * 10) + new Vector2(transform.position.x, transform.position.y);

        }
    }
}
