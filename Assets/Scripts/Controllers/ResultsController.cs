using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controladores {

	public class ResultsController : MonoBehaviour {

		public int vidasCorrente;
		public int vidasTotais;

		public int qtdAcertos;

		public int aproveitamentoTotal {
			get { 
				var v = aproveitamentoVidas;
				var q = aproveitamentoAcertos;

				return (int)((v + q) / 2);
			}
		}

		public int aproveitamentoVidas {
			get { 
				return (int)(vidasCorrente / vidasTotais) * 100;
			}
		}

		public int aproveitamentoAcertos {
			get { 
				return (int)(qtdAcertos / GameController.k_MaxQuestions) * 100;
			}
		}

		public string aproveitamentoTotalLabel {
			get { 
				return aproveitamentoTotal + "%";
			}
		}

		public string aproveitamentoVidasLabel {
			get { 
				return aproveitamentoVidas + "%";
			}
		}

		public string aproveitamentoAcertosLabel {
			get { 
				return aproveitamentoAcertos + "%";
			}
		}

		// Use this for initialization
		void Start () {
			DontDestroyOnLoad (gameObject);

		}

		public string GetVidasLabel() {
			var sep = " de ";
			return vidasCorrente + sep + vidasTotais;
		}

		public string GetAcertosLabel() {
			var sep = " de ";
			return qtdAcertos + sep + GameController.k_MaxQuestions;
		}
	}

}
