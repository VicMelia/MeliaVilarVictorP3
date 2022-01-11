using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBook : MonoBehaviour
{
    public IQTimer iqTimerScript;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            iqTimerScript.seconds -= 10f;
            Destroy(this.gameObject);
        }
    }
}
