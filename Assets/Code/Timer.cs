using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public float valueTime=60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(valueTime > 0){
            valueTime -=Time.deltaTime;
        }
        else{
            valueTime=0;
        }
        DisplayTime(valueTime);
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay<0){
            timeToDisplay=0;
        }
        float min= Mathf.FloorToInt(timeToDisplay / 60);
        float sec= Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format( "{0:00}:{1:00}" , min, sec);

        if(min==0.0 && sec==0.0){
            SceneManager.LoadScene("03");
            
        }
    }
}
