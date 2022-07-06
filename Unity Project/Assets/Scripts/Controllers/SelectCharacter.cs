using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public int characterIndex = 0;
    public int counter = 1;

    public void Next(){
        characters[characterIndex].SetActive(false);
        characterIndex = (characterIndex + 1) % characters.Length;
        characters[characterIndex].SetActive(true);
    }

    public void Previous(){
        characters[characterIndex].SetActive(false);
        characterIndex--;

        // check when index goes out of bounds
        if(characterIndex < 0){
            characterIndex += characters.Length;
        }
        characters[characterIndex].SetActive(true);
    }
    public void StartGame(){
        switch(characterIndex){
            case 0:
                SceneManager.LoadScene("Level 1 Female", LoadSceneMode.Single);
                break;
            case 1:
                SceneManager.LoadScene("Level 1 Male", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("Level 1 Zombie", LoadSceneMode.Single);
                break;
        }
    }
}
