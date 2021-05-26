using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] Move Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(){
        PlayerPrefs.SetInt("CurrentScore", Player._score);
        GameObject[] Foods =  GameObject.FindGameObjectsWithTag("Oreo");
        string content = "";
        foreach(GameObject F in Foods){
           string pos =   F.transform.position.x +"," + F.transform.position.y;
           content +=pos +"/";
        }
        Debug.Log(content);
    }
}
