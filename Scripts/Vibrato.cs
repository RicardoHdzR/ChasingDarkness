using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrato : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 pos;
    public float lapse;
    public float hfreq;
    public float vfreq;
    public float amp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos + new Vector2(Mathf.Sin(hfreq * Time.time / lapse), Mathf.Sin(vfreq * Time.time / lapse)) * amp;
    }
}
