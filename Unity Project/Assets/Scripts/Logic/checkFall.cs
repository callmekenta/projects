using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkFall : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Female Character" || other.gameObject.name == "Male Character"  || other.gameObject.name == "Zombie" ){
            SceneManager.LoadScene("Death", LoadSceneMode.Single);
        } 
    }
}
