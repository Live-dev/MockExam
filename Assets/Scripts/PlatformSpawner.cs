using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //platforms to be spawned
    public GameObject[] platform;
    public GameObject [] breakablePlatform;
  
    
    public GameObject[] movingPlatform;

 //spawn timer
    public float platform_spawn_timer = 0.5f;
    private float current_platform_spawn_timer;
    private int spawn_count;

    public float min_X =-1.86f , max_X =1.76f ;

    // Start is called before the first frame update
    void Start()
    {
        current_platform_spawn_timer = platform_spawn_timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spawner();
      
    }
   
    void Spawner()
    {
        current_platform_spawn_timer += Time.deltaTime;
        if(current_platform_spawn_timer>=platform_spawn_timer)
        {
            spawn_count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);
            Vector3 pos = transform.position;
          
           
            pos.x = temp.x + Random.Range(0,1);


            GameObject newPlatform = null;
            if (spawn_count < 2)
            {

                newPlatform = Instantiate(platform[Random.Range(0, platform.Length)], temp, Quaternion.identity);
            }
            else if (spawn_count == 2)
            {
                if (Random.Range(0, 2) > 0)
                {

                    newPlatform = Instantiate(platform[Random.Range(0, platform.Length)], temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatform[Random.Range(0, movingPlatform.Length)], pos, Quaternion.identity);
                }
            }
            else if (spawn_count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(breakablePlatform[Random.Range(0, breakablePlatform.Length)], pos, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatform[Random.Range(0, movingPlatform.Length)], pos, Quaternion.identity);
                }
            }
            else if (spawn_count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platform[Random.Range(0, platform.Length)], temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform[Random.Range(0,breakablePlatform.Length)], pos, Quaternion.identity);
                }

            }
            else if (spawn_count == 5)
            {
                newPlatform = Instantiate(breakablePlatform[Random.Range(0, breakablePlatform.Length)], pos, Quaternion.identity); spawn_count = 0;
            }
                newPlatform.transform.parent = transform;
            current_platform_spawn_timer = 0f;
        }
       
    }
}
