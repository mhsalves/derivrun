using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controladores;

namespace Componentes {

	public class HUDContadores : MonoBehaviour {

		public readonly static int k_MinQuestions = 1;
		public readonly static int k_MaxQuestions = 10;

		[SerializeField] private Text m_Contador;
		[SerializeField] private Text m_Acertos;
		[SerializeField] private Text m_Vidas;

		private int _NQ = HUDContadores.k_MinQuestions;
		private int m_NumQuestao {
			set { 
				m_Contador.text = "" + value;
				_NQ = value;
			}	
			get {
				return _NQ;
			}
		}

		private int _NA = 0;
		private int m_NumAcertos {
			set {
				m_Acertos.text = "" + value;
				_NA = value;
			}
			get { 
				return _NA;
			}
		}
		public int GetAcertos() {
			return m_NumAcertos;
		}

		void Awake () {
			this.m_NumQuestao = HUDContadores.k_MinQuestions;
			this.m_NumAcertos = 0;

		}


		public void LoadValues ( int numVidas ) {
			m_Vidas.text = "" + numVidas;
		}

		public bool ProximaQuestao() {
			m_NumQuestao++;
			if (m_NumQuestao > k_MaxQuestions) {
				m_NumQuestao = k_MaxQuestions;
				return true; //Pare agora
			} else {
				return false; //Nao pare agora
			}
		}

		public void Pontuar() {
			m_NumAcertos++;
		}

	}

}