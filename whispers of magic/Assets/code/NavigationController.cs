using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public void GoToIntroScene()
    {
        Application.LoadLevel(0);
    }
    public void GoToGameScene()
    {
        Application.LoadLevel(3);
    }
    public void GoToGameOver()
    {
        Application.LoadLevel(1);
    }
    public void GoToVictoryScene()
    {
        Application.LoadLevel(2);
    }

    public void Quit()
    {
        Application.Quit();
    }









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
