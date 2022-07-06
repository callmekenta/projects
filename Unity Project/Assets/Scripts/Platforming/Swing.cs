using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
	[SerializeField] public float speed = 1.5f;
	[SerializeField] private float degree = 75f; 
	[SerializeField] public bool randomStart = true; 
	private float random = 0;


	void Awake()
    {
		if(randomStart)
			random = Random.Range(0f, 2f);
	}

    // Update is called once per frame
    void Update()
    {
		float angle = degree * Mathf.Sin(Time.time + random * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
