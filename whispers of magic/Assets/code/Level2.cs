using System.Collections;
using UnityEngine;
public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    //If checked, a GameObject can trigger an event when it collides with another GameObject.
    // This is useful for settng up events you want to happen when your player comes in contact with them.

    void OnTriggerEnter2D(Collider2D Other)
    {
        //if the collider of the object whose name is Sonic GameObject touches the checkPoint's circle collider
        if (Other.name == "Player")
            FindObjectOfType<LevelManager2>().CurrentCheckpoint = this.gameObject;
        //go to the level manager script, and update the value of CurrentCheckpoint to become the new CheckPoint the player has
        // just passed through. This is necessary when you have several checkpoints in a level..
    }
}