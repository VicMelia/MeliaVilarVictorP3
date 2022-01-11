using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorial : MonoBehaviour
{

    public GameObject menu;
    public bool menu_tutorial;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            menu.SetActive(true);
            menu_tutorial = true;
        }
    }

    public void BotonNext()
    {
        menu.SetActive(false);
        menu_tutorial = false;
        Destroy(this.gameObject);
    }

}
