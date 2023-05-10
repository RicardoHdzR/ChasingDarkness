using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("dial",2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void dial()
    {
        text.text = "Dios, no puedo creer que me quedara toda la noche estudiando para el examen sin darme cuenta, estoy muerta... \nA este paso no llegare ni a la siguiente clase...";
        
    }
    
}
