using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Change(string scene_name){
        SceneManager.LoadScene(scene_name);

    }
    
}
