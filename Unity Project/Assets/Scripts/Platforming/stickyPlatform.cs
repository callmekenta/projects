using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{

    public GameObject Player;

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "Player"){
            Debug.Log("Works");
        }
        Player.transform.parent = other.transform;
        Debug.Log("Works");
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.name == "Player"){
            Debug.Log("Works");
        }
        Player.transform.parent = null;
        Debug.Log("Works");
    }
}
