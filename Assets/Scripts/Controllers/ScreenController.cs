using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controladores {

	public class ScreenController : MonoBehaviour {

		void Start() {
			DontDestroyOnLoad (gameObject);

		}
			
		public void AbrirMain() {
			SceneManager.LoadScene (1);
		}

		public void AbrirGame() {
			SceneManager.LoadScene (2);
		}

		public void AbrirEnd() {
			SceneManager.LoadScene (3);
		}

		public void AbrirGuide() {
			SceneManager.LoadScene (4);
		}
	}

}