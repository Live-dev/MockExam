using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField]
    private int Points;
  

    public Text HighScore;
    public Text Scoretext;


   


    private void Start()
    {
        //saving highscore 
        HighScore.text = PlayerPrefs.GetInt("",0).ToString();
    }
    void Update()
    {
    
                   
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //incrementing score 
        if (collision.gameObject.tag == "Collect")
        {
       
            Points++;
           
           //destroying collectables 
            Destroy(collision.gameObject);
            if (Points > PlayerPrefs.GetInt("",0))
            {
                PlayerPrefs.SetInt("", Points);
                HighScore.text = Points.ToString();
            }

        }
        if (collision.gameObject.tag == "rock")
        {


            Points--;
        }
        Scoretext.text = "" + Points.ToString();
    }
    
       
    
    
    
    

}
