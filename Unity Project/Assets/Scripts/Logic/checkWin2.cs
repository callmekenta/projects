using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkWin2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Female Character"){
            SceneManager.LoadScene("Level 3 Female", LoadSceneMode.Single);
        }
        else if(other.gameObject.name == "Male Character"){
            SceneManager.LoadScene("Level 3 Male", LoadSceneMode.Single);
        }
        else if(other.gameObject.name == "Zombie"){
            SceneManager.LoadScene("Level 3 Zombie", LoadSceneMode.Single);
        }
    }
}
