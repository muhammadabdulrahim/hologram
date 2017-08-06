using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Handler : MonoBehaviour
{
	public GameObject objectToFollow;
	public float speed;
	private Rigidbody rb;
	private float timeStamp;
	private float magnitude;
	private float initialY;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		initialY = transform.position.y;
		magnitude = transform.position.x;
	}
	
	void Update()
	{
		timeStamp += speed * Time.deltaTime;
		float nextX = Mathf.Cos(timeStamp) * magnitude;
		float nextZ = Mathf.Sin(timeStamp) * magnitude;
		Vector3 nextPosition = new Vector3(nextX, initialY, nextZ);
		rb.AddForce(nextPosition - transform.position);

	}
}
