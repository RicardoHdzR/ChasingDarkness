using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        text.rectTransform.position = new Vector2(0, 0);
        Invoke("whisper", 3f);
        Invoke("shout", 6f);
        Invoke("keys", 9f);
        Invoke("exit", 12f);
        Invoke("luck", 15f);
        Invoke("clear", 18f);
    }
    void whisper()
    {
        text.rectTransform.position = new Vector2(0,0);
        text.text = "Press [X] to whisper";
    }

    void shout()
    {
        text.rectTransform.position = new Vector2(0, 0);
        text.text = "Long press [X] to shout";
    }

    void keys()
    {
        text.rectTransform.position = new Vector2(0, 0);
        text.text = "Find the keys...";
    }

    void exit()
    {
        text.rectTransform.position = new Vector2(0, 0);
        text.text = "...With the keys find the exit to escape...";
    }
    void luck()
    {
        text.rectTransform.position = new Vector2(0, 0);
        text.text = "...good luck...";
    }
    void clear()
    {
        text.rectTransform.position = new Vector2(0, 0);
        text.text = "";
    }
}
