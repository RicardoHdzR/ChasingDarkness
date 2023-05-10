using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator animator; 
    void Start()
    {
        
    
        }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadScene()
    {
        SceneManager.LoadScene("Escuela Prosedural");
    }

    public void leaveScene()
    {
        Application.Quit();
    }

    public void credits()
    {
        animator.SetBool("Activar",true);
        Invoke("Desactivar", 1f);
    }

    void Desactivar()
    {
        animator.SetBool("Activar", false);
    }
}
