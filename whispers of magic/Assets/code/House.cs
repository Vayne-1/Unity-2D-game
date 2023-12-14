using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    //function that executes upon trigger (when something collides with the spikes)
    //If checked, a GameObject can trigger an event when it collides with another GameObject.
    // This is useful for settng up events you want to happen when your player comes in contact with them.

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            //if the collider of the object whose name is Sonic GameObject touches the spike collider
            FindObjectOfType<LevelManager2>().RespawnPlayer();
        //go to the level manager script, and execute the respawn player function .. (hyro7 l a5er checkPoint)
    }
}
