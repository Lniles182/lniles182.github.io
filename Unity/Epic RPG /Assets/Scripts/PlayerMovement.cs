using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 4f;

	Animator anim;

	float lastX, lastY;

	void Start()
	{
		anim = GetComponent<Animator>();

	}
	void Update()
	{
		Move();
	}

	void Move()
	{
		Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");

		Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

		transform.position += rightMovement;
		transform.position += upMovement;

		UpdateAnimation(heading);
	}

	void UpdateAnimation(Vector3 dir)
	{
		if (dir.x == 0 && dir.y == 0)
		{
			anim.SetFloat("LastDirX", lastX);

			anim.SetFloat("LastDirY", lastY);

			anim.SetBool("Movement", false);
		}
		else
		{
			lastX = dir.x;
			lastY = dir.y;
			anim.SetBool("Movement", true);
		}

		anim.SetFloat("DirX", dir.x);
		anim.SetFloat("DirY", dir.y);

	}
}
