using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformm : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    public float bound_Y = 6.0f;

  

    public bool moving_platform_left, moving_platform_right, is_breakable, is_platform;
    
    private void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
       
        
        Move();
    }
    //setting up movement
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            Destroy(this.gameObject);
            
        }
    }

    void DeactivateGameObject()
    {
     //   SoundManager.instance.BreakSound();
        gameObject.SetActive(false);
    }
   
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //deactivating the breakable platform
            if (is_breakable)
            {
                Invoke("DeactivateGameObject", 0.3f);

            }
            if (is_platform)
            {
              
               
              //  SoundManager.instance.LandSound();
           
            }
            


        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if on this platform the player moves left
            if (moving_platform_left)
            {
              
                collision.gameObject.GetComponent<PlayerController>().Platformmove(-2f);
              

            }
            //if on this platform the player moves right
            if (moving_platform_right)
            {
               
                collision.gameObject.GetComponent<PlayerController>().Platformmove(2f);
               

            }

        }
    }
}

