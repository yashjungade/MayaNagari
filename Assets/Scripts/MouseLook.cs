using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 1000f;
	public Transform playerBody;
	float xRotation=0f;

	void Start()
	{

	}

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
		xRotation -= mouseX;
		transform.localRotation = Quaternion.Euler(-0f,-xRotation,0f);
		playerBody.Rotate(Vector3.down*mouseX);

	}
}