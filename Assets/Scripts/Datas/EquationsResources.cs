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

			public List<Resposta> respostas {
				get { 
					var l = new List<Resposta> ();
					l.Add (resposta0);
					l.Add (resposta1);
					l.Add (resposta2);
					l.Add (resposta3);

					return l;
				}
			}

		}

		[System.Serializable]
		public struct Resposta {
			public Sprite sprite;
			public bool correta;
		}
			
		public List<Data> dados;

		public Data SelecionarDataAleatoria( bool shuffle = false ) {
			int i = RandomUtils.RandomInt (0, dados.Count);
			var item = dados [i];

			if (shuffle) ListUtils.Shuffle (item.respostas);

			return item;
		}


	}

}