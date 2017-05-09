using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controladores {

	public class ResultsController : MonoBehaviour {

		public int vidasCorrente;
		public int vidasTotais;

		public int qtdAcertos;


		// Use this for initialization
		void Start () {
			DontDestroyOnLoad (gameObject);

		}

		public string GetAproveitamento() {
			var v = vidasCorrente / vidasTotais * 100;
			var q = qtdAcertos / GameController.maxQuestions * 100;

			return ((int) ((v+q)/2)) + "%"; 
		}

		public string GetVidasLabel() {
			var sep = " de ";
			return vidasCorrente + sep + vidasTotais;
		}

		public string GetAcertosLabel() {
			var sep = " de ";
			return qtdAcertos + sep + GameController.maxQuestions;
		}
	}

}
