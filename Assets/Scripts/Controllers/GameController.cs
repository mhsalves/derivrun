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

		public EquationsResources equationsResources;
		public EquationsArea equationsArea;

		public ScreenController screenController;
		private LifeController lifeController;
		public ResultsController resultsController;

		public readonly static int maxQuestions = 10;
		public readonly static int minQuestions = 1;

		public Text tQuestion;
		public Text tScore;
		public Text tLifes;

		public int nQuestion = GameController.minQuestions;
		public int nScore = 0;

		public BlocoSpawnBehavior spawnInicialIsolado;
		public CameraMoveBehavior cameraBehavior;
		public PlayerBehavior player;
		public ContadorInicial contadorInicial;

		public int contadorDeBlocos = 0;

		// Use this for initialization
		void Start () {

			this.lifeController = GameObject.Find ("LifeController").GetComponent<LifeController> ();
			var questaoAtual = equationsResources.SelecionarDataAleatoria ();
			this.equationsArea.Carregar (questaoAtual);

			tQuestion.text = "" + nQuestion;
			tScore.text = "" + nScore;
			tLifes.text = "" + this.lifeController.GetVidas ();

			spawnInicialIsolado.InvocarLimpo ();
			this.contadorDeBlocos = spawnInicialIsolado.childAhead - 1;

			this.player.Mover (PlayerBehavior.Direcao.NENHUM);
			contadorInicial.Comecar ();



		}

		public void Iniciar() {

			//Começar a mexer camera
			cameraBehavior.Mover ();
			this.player.Mover (PlayerBehavior.Direcao.FRENTE);

		}

		public void ValidarResposta( int indiceResposta ){
		
			var r = this.equationsArea.VerificarCorreto (indiceResposta);

			if (r) {
				this.Pontuar ();
			} else {
				this.PerderVida ();
			}

			var finish = this.NextQuestion ();
			if (finish) {
				this.AtualizarResults ();
				this.EndGame ();
			}

		}

		private void Pontuar() {
			nScore++;
			tScore.text = "" + nScore;
		}

		private bool NextQuestion() {
		
			nQuestion++;
			if (nQuestion > maxQuestions) {
				return true; //Acabou !
			} else {
				tQuestion.text = "" + nQuestion;

				var data = equationsResources.SelecionarDataAleatoria ();
				equationsArea.Carregar (data);

				return false; //Ainda não acabou
			}
		}

		private void PerderVida(){

			var p = lifeController.PerderVida ();

			if (p) {
				this.AtualizarResults ();
				this.EndGame ();

			} else {
				tLifes.text = "" + this.lifeController.GetVidasCorrente ();

			}

		}

		private void AtualizarResults() {
			resultsController.vidasTotais = lifeController.GetVidas ();
			resultsController.vidasCorrente = lifeController.GetVidasCorrente ();
			resultsController.qtdAcertos = nScore;
		}

		public void PauseGame() {
			Time.timeScale = 0.0f;
		}

		public void ResumeGame() {
			Time.timeScale = 1.0f;
		}

		public void EndGame() {
			screenController.AbrirEnd ();
		}

	}

}
