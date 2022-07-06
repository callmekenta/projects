using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(speed * Time.deltaTime / 0.01f, 0f, 0f, Space.Self);
	}
}
