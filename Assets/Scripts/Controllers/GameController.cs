using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public EquationsResources equationsResources;
	public EquationsArea equationsArea;

	public ScreenController screenController;
	private LifeController lifeController;

	private static int maxQuestions = 10;
	private static int minQuestions = 1;

	public Text tQuestion;
	public Text tScore;
	public Text tLifes;

	public int nQuestion = GameController.minQuestions;
	public int nScore = 0;

	public BlocoSpawnBehavior spawnInicialIsolado;
	public CameraBehavior cameraBehavior;
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
		contadorInicial.Comecar ();

	}
	
	// Update is called once per frame
	void Update () {



	}

	public void Iniciar() {

		//Começar a mexer camera
		cameraBehavior.mexer = true;
		player.Andar ();



	}

	public void ValidarResposta( int indiceResposta ){
	
		var r = this.equationsArea.VerificarCorreto (indiceResposta);

		if (r) {
			this.Pontuar ();
		} else {
			this.PerderVida ();
			print ("perder vida");
		}

		var finish = this.NextQuestion ();
		if (finish) {
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
			this.EndGame ();

		} else {
			tLifes.text = "" + this.lifeController.GetVidasCorrente ();

		}

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
