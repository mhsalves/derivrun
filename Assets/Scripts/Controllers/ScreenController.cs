using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour {

	void Start() {
		DontDestroyOnLoad (gameObject);

	}

	public void AbrirGame() {
		SceneManager.LoadScene (1);
	}

	public void AbrirEnd() {
		SceneManager.LoadScene (2);
	}

	public void AbrirMain() {
		SceneManager.LoadScene (0);
	}

	public void AbrirGuide() {
		SceneManager.LoadScene (3);
	}
}
