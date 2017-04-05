using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilitarios;

public class EquationsArea : MonoBehaviour {

	public Image pergunta;
	public Image resposta0;
	public Image resposta1;
	public Image resposta2;
	public Image resposta3;

	private List<EquationsResources.Resposta> lista = new List<EquationsResources.Resposta>();

	public void Carregar(EquationsResources.Data data){

		this.lista = GerarListaRespostas (data);

		this.pergunta.sprite = data.pergunta;
		this.resposta0.sprite = this.lista[0].sprite;
		this.resposta1.sprite = this.lista[1].sprite;
		this.resposta2.sprite = this.lista[2].sprite;
		this.resposta3.sprite = this.lista[3].sprite;	
	
	}
	

	private List<EquationsResources.Resposta> GerarListaRespostas( EquationsResources.Data data ) {

		var list = new List<EquationsResources.Resposta> ();
		list.Add (data.resposta0);
		list.Add (data.resposta1);
		list.Add (data.resposta2);
		list.Add (data.resposta3);

		ListUtils.Shuffle (list);

		return list;
	}

	public bool VerificarCorreto ( int indice ) {
		return this.lista [indice].correta;	
	}

}
