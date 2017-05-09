using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitarios;

namespace InformacoesEstaticas {

	public class EquationsResources : MonoBehaviour {

		[System.Serializable]
		public struct Data
		{
			public Sprite pergunta;
			public Resposta resposta0;
			public Resposta resposta1;
			public Resposta resposta2;
			public Resposta resposta3;
		}

		[System.Serializable]
		public struct Resposta {
			public Sprite sprite;
			public bool correta;
		}
			
		public List<Data> dados;


		public Data SelecionarDataAleatoria() {
			int i = RandomUtils.RandomInt (0, dados.Count);
			return dados [i];
		}


	}

}