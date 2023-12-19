using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finallevel : MonoBehaviour
{
    public string scenename;
    private BossHealth Boss;
    void Start()
    {
        Boss = FindObjectOfType<BossHealth>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //if the collider of the object whose name is Sonic GameObject touches the spike collider
            //FindObjectOfType<LevelManager>().RespawnPlayer();
            //go to the level manager script, and execute the respawn player function .. (hyro7 l a5er checkPoint)
             if (Boss.health <= 0)
            {
            SceneManager.LoadScene(scenename);
            }
        }
    }


}
