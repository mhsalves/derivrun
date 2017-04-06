using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public float speed = 1f;
	public bool mexer = false;

	void Update() {
		if (mexer) {
			transform.Translate (0f, speed * Time.deltaTime, 0f);
		}
	}
}
