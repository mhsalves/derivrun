using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Componentes;
using PlayerScripts;
using CameraScripts;
using BlocoScripts;
using InformacoesEstaticas;

namespace Controladores {

	public class GameController : MonoBehaviour {

		[SerializeField] private EquationsResources m_EquationsResources;
		[SerializeField] private EquationsArea m_EquationsArea;

	 	public ScreenController m_ScreenController;
		private LifeController c_LifeController;
		private ResultsController c_ResultsController;

		[SerializeField] private HUDContadores m_HUDContadores;

		[SerializeField] private BlocoSpawnBehaviour m_SpawnIsolado;

		private CameraMoveBehaviour m_CameraMoveBehaviour;
		private PlayerBehaviour m_Player;
		[SerializeField] private ContadorInicial m_ContadorInicial;

		public int numBlocos = 0;

		void Awake () {
			
			this.c_LifeController = GameObject.FindGameObjectWithTag ("LifeController").GetComponent<LifeController> ();
			this.c_ResultsController = GameObject.FindGameObjectWithTag ("ResultsController").GetComponent<ResultsController> ();

			this.m_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerBehaviour> ();
			this.m_CameraMoveBehaviour = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMoveBehaviour> ();
		}

		// Use this for initialization
		void Start () {

			this.c_LifeController.IniciarCom (this.c_LifeController.GetVidas ());
			this.AtualizarResults ();

			this.CarregarQuestaoNova ();
			this.m_HUDContadores.LoadValues (this.c_LifeController.GetVidas ());

			this.m_SpawnIsolado.InvocarLimpo ();
			this.numBlocos = m_SpawnIsolado.childAhead - 1;

			this.m_Player.Mover (PlayerBehaviour.Direcao.NENHUM);
			this.m_ContadorInicial.Comecar ();

		}

		public void Iniciar() {

			//Começar a mexer camera
			this.m_CameraMoveBehaviour.Mover ();
			this.m_Player.Mover (PlayerBehaviour.Direcao.FRENTE);

		}

		private void CarregarQuestaoNova() {

			var questaoAtual = this.m_EquationsResources.SelecionarDataAleatoria ();
			this.m_EquationsArea.Carregar (questaoAtual);

		}

		public void ValidarResposta( int indiceResposta ){
		
			var r = this.m_EquationsArea.VerificarCorreto (indiceResposta);

			if (r) {
				this.m_HUDContadores.Pontuar ();
				//TODO animar correto
			} else {
				this.PerderVida ();
				//TODO animar errado
			}

			var pararAgora = this.m_HUDContadores.ProximaQuestao ();
			if (pararAgora) {
				this.AtualizarResults ();
				this.EndGame ();
			} else {
				this.CarregarQuestaoNova ();
			}

		}

		private void PerderVida(){

			var p = c_LifeController.PerderVida ();

			if (p) {
				this.AtualizarResults ();
				this.EndGame ();

			} else {
				this.m_HUDContadores.LoadValues (c_LifeController.GetVidasCorrente ());
			}

		}

		private void AtualizarResults() {
			c_ResultsController.vidasTotais = c_LifeController.GetVidas ();
			c_ResultsController.vidasCorrente = c_LifeController.GetVidasCorrente ();
			c_ResultsController.qtdAcertos = this.m_HUDContadores.GetAcertos ();
		}

		public void PauseGame() {
			Time.timeScale = 0.0f;
		}

		public void ResumeGame() {
			Time.timeScale = 1.0f;
		}

		public void EndGame() {
			m_ScreenController.AbrirEnd ();
		}

	}

}
