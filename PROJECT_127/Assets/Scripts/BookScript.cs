using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{

    public IQTimer iqTimerScript;
    
    

   public void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            iqTimerScript.seconds += 20f;
           
            Destroy(this.gameObject);
        }
    }
}
