using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateFood : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 1f, 0f, Space.Self);
    }
}
