using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControll : MonoBehaviour
{
    private Animator animator1;
   
    public FlyingEnemy[] enemArr;
    void Start()
    {
        
        animator1 = GetComponent<Animator>();
    }
    void Update()
    {
           
        
    } 
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player")){
            foreach(FlyingEnemy enemy in enemArr)
            {
                enemy.chase = true;
             
               
                    animator1.SetTrigger("boxTr");
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.CompareTag("Player")){
            foreach (FlyingEnemy enemy in enemArr)
            {
                enemy.chase = false;
            }
        }
    }
  
}
