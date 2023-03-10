using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

	public Transform player;

	public bool isFacingRight = false;

	public void LookAtPlayerFunc()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFacingRight)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFacingRight = false;
		}
		else if (transform.position.x < player.position.x && !isFacingRight)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFacingRight = true;
		}
	}

}
