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

		public readonly static int k_MaxQuestions = 10;
		public readonly static int k_minQuestions = 1;

		[SerializeField] private Text m_Question;
		[SerializeField] private Text m_Score;
		[SerializeField] private Text m_Lifes;

		private int numQuestion = GameController.k_minQuestions;
		private int numScore = 0;

		[SerializeField] private BlocoSpawnBehaviour m_SpawnIsolado;

		public CameraMoveBehaviour m_CameraMoveBehaviour;
		public PlayerBehaviour m_Player;
		[SerializeField] private ContadorInicial m_ContadorInicial;

		public int numBlocos = 0;

		void Awake () {
			
			this.c_LifeController = GameObject.FindGameObjectWithTag ("LifeController").GetComponent<LifeController> ();
			this.c_ResultsController = GameObject.FindGameObjectWithTag ("ResultsController").GetComponent<ResultsController> ();

		}

		// Use this for initialization
		void Start () {

			this.c_LifeController.IniciarCom (this.c_LifeController.GetVidas ());
			this.AtualizarResults ();
			var questaoAtual = this.m_EquationsResources.SelecionarDataAleatoria ();

			this.m_EquationsArea.Carregar (questaoAtual);

			this.m_Question.text = "" + numQuestion;
			this.m_Score.text = "" + numScore;
			this.m_Lifes.text = "" + this.c_LifeController.GetVidas () ?? "1";

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

		public void ValidarResposta( int indiceResposta ){
		
			var r = this.m_EquationsArea.VerificarCorreto (indiceResposta);

			if (r) {
				this.Pontuar ();
				//TODO animar correto
			} else {
				this.PerderVida ();
				//TODO animar errado
			}

			var finish = this.NextQuestion ();
			if (finish) {
				this.AtualizarResults ();
				this.EndGame ();
			}

		}

		private void Pontuar() {
			numScore++;
			m_Score.text = "" + numScore;
		}

		private bool NextQuestion() {
		
			numQuestion++;
			if (numQuestion > k_MaxQuestions) {
				return true; //Acabou !
			} else {
				m_Question.text = "" + numQuestion;

				var data = m_EquationsResources.SelecionarDataAleatoria ();
				m_EquationsArea.Carregar (data);

				return false; //Ainda não acabou
			}
		}

		private void PerderVida(){

			var p = c_LifeController.PerderVida ();

			if (p) {
				this.AtualizarResults ();
				this.EndGame ();

			} else {
				m_Lifes.text = "" + this.c_LifeController.GetVidasCorrente ();

			}

		}

		private void AtualizarResults() {
			c_ResultsController.vidasTotais = c_LifeController.GetVidas ();
			c_ResultsController.vidasCorrente = c_LifeController.GetVidasCorrente ();
			c_ResultsController.qtdAcertos = numScore;
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
