﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InformacoesEstaticas;
using Managers;
using Utilitarios;

namespace Componentes {

	public class HUDQuestoes : MonoBehaviour {
		
		[SerializeField] private Image m_Pergunta;
		[SerializeField] private Image m_Resposta0;
		[SerializeField] private Image m_Resposta1;
		[SerializeField] private Image m_Resposta2;
		[SerializeField] private Image m_Resposta3;

		private QuestionInterface _Question;
		private QuestionInterface m_Question {
			set { 
				_Question = value;
				m_Pergunta.sprite = value.enunciado;
				m_Resposta0.sprite = value.resposta_1.sprite;
				m_Resposta1.sprite = value.resposta_2.sprite;
				m_Resposta2.sprite = value.resposta_3.sprite;
				m_Resposta3.sprite = value.resposta_4.sprite;
			}
			get { return _Question; }
		}

		void Awake () {

			//Determinando uma questao inicial
			this.LoadNovaQuestao();

		}

		public void LoadNovaQuestao() {
			print ("Load NEW");
			int max = StorageManager.ReadQuantity ();
			int value = RandomUtils.RandomInt (0, max);
			print ("Para: " + value);
			m_Question = StorageManager.ReadEquation (value);
		}

		public bool VerificarAcerto( int indice ) {
			return m_Question.respostas [indice].is_correta;
		}


	}

}