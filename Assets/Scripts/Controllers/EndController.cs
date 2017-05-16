using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controladores {

	public class EndController : MonoBehaviour {

		private ResultsController c_ResultsController;

		[SerializeField] private Text m_Titulo;

		[SerializeField] private Text m_Aproveitamento;
		[SerializeField] private Text m_Vidas;
		[SerializeField] private Text m_Acertos;

		[SerializeField] private Text m_AproveitamentoVidas;
		[SerializeField] private Text m_AproveitamentoAcertos;

		// Use this for initialization
		void Awake () {
			this.c_ResultsController = GameObject.FindGameObjectWithTag ("ResultsController").GetComponent<ResultsController> ();

		}

		void Start () {
			this.AtualizarDados ();

		}

		private void AtualizarDados() {
			
			var v = this.c_ResultsController.vidasCorrente;
			var ap = this.c_ResultsController.aproveitamentoTotal;

			this.m_Aproveitamento.text = this.c_ResultsController.aproveitamentoTotalLabel;
			this.m_AproveitamentoAcertos.text = this.c_ResultsController.aproveitamentoAcertosLabel;
			this.m_AproveitamentoVidas.text = this.c_ResultsController.aproveitamentoVidasLabel;

			this.m_Vidas.text = this.c_ResultsController.GetVidasLabel ();
			this.m_Acertos.text = this.c_ResultsController.GetAcertosLabel ();

			this.m_Titulo.text = this.GetTitulo (ap, v);

		}

		private string GetTitulo ( int aproveitamento, int vidas ) {

			if (vidas == 0 || aproveitamento < 30f)
				return "Tente de novo !";
			else if (aproveitamento < 50f)
				return "Ta melhorando !";
			else if (aproveitamento < 75f)
				return "Quase lá !";
			else
				return "Parabéns !";

		}

	}

}
