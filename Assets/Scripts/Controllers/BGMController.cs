using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	private AudioSource source;

	void Start() {
		DontDestroyOnLoad (transform.gameObject);
		source = GetComponent<AudioSource> ();

	}

}
