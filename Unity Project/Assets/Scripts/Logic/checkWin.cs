using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkWin : MonoBehaviour
{
    private int fromOtherScript_index;

    // Attempt to use a switch case to load in scenes 
    // void Start(){
    //     GameObject selectCharacter = GameObject.Find("Select Character");
    //     SelectCharacter index = selectCharacter.GetComponent<SelectCharacter>();
    //     fromOtherScript_index = index.characterIndex;
    //     Debug.Log(fromOtherScript_index);
    // }
    // private void OnTriggerEnter(Collider other){

    //     switch(fromOtherScript_index){
    //         case 0:
    //             SceneManager.LoadScene("Level 2 Female", LoadSceneMode.Single);
    //             counter++;
    //             break;
    //         case 1:
    //             SceneManager.LoadScene("Level 2 Male", LoadSceneMode.Single);
    //             counter++;
    //             break;
    //         case 2:
    //             SceneManager.LoadScene("Level 2 Zombie", LoadSceneMode.Single);
    //             counter++;
    //             break;
    //     }
    // }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Female Character"){
            SceneManager.LoadScene("Level 2 Female", LoadSceneMode.Single);
        }
        else if(other.gameObject.name == "Male Character"){
            SceneManager.LoadScene("Level 2 Male", LoadSceneMode.Single);
        }
        else if(other.gameObject.name == "Zombie"){
            SceneManager.LoadScene("Level 2 Zombie", LoadSceneMode.Single);
        }
    }
}
