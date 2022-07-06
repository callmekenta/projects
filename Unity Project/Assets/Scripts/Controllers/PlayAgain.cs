using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame(){
        SceneManager.LoadScene("Character Selection", LoadSceneMode.Single);
    }
}
