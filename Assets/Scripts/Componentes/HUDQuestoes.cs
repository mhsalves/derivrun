using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InformacoesEstaticas;

namespace Componentes {

	public class HUDQuestoes : MonoBehaviour {

		[SerializeField] private EquationsResources m_EquationsResources;

		[SerializeField] private Image m_Pergunta;
		[SerializeField] private Image m_Resposta0;
		[SerializeField] private Image m_Resposta1;
		[SerializeField] private Image m_Resposta2;
		[SerializeField] private Image m_Resposta3;

		private EquationsResources.Data _D;
		private EquationsResources.Data m_Data {
			set { 
				_D = value;
				m_Pergunta.sprite = value.pergunta;
				m_Resposta0.sprite = value.resposta0.sprite;
				m_Resposta1.sprite = value.resposta1.sprite;
				m_Resposta2.sprite = value.resposta2.sprite;
				m_Resposta3.sprite = value.resposta3.sprite;
			}
			get { 
				return _D;
			}
		}

		void Awake () {

			//Determinando uma questao inicial
			this.LoadNovaQuestao();

		}

		public void LoadNovaQuestao() {
			m_Data = m_EquationsResources.SelecionarDataAleatoria (true);

		}

		public bool VerificarAcerto( int indice ) {
			return m_Data.respostas [indice].correta;
		}


	}

}