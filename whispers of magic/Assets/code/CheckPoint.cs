using System.Collections;
using UnityEngine;
public class CheckPoint : MonoBehaviour
   
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
        audioManager.PlaySFX(audioManager.checkpoint);
        //if the collider of the object whose name is Sonic GameObject touches the checkPoint's circle collider
        if (Other.tag == "Player")
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject;
        //go to the level manager script, and update the value of CurrentCheckpoint to become the new CheckPoint the player has
        // just passed through. This is necessary when you have several checkpoints in a level..
    }
}