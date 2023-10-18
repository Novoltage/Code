using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    private Panel panel;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Panel>();
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            
            IsPause();
        }
    }

    public void Mainmenu()

    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        transform.GetChild(0).gameObject.SetActive(false);
    }




    public void IsPause()
    {
        
            
        Time.timeScale = 0;
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
        Physics2D.IgnoreLayerCollision(10, 11, true);
        transform.GetChild(0).gameObject.SetActive(true);
     
    }


   

}
