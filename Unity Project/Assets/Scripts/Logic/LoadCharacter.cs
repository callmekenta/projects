using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{   
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start(){
        int characterIndex = PlayerPrefs.GetInt("characterIndex");
        GameObject prefab = characterPrefabs[characterIndex];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
