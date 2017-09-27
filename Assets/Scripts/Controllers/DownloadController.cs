using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using Models;
using Controladores;

namespace DownloadManager {
	
	public class DownloadController : MonoBehaviour {
		
		[SerializeField] private DownloadFeedback m_DownloadFeedback;
		[SerializeField] private InitialController m_InitialController;

		public List<Formula> formulas = new List<Formula>();

		private DownloadManager m_DownloadManager;

		void Start() {
			this.formulas = StorageManager.LoadJSON ();

			this.m_DownloadFeedback.Init (formulas.Count);

			IniciarDownloads ();
		}

		private void IniciarDownloads() {
			
			Formula formula = this.formulas [this.m_DownloadFeedback.counter];
//			Debug.Log (formula.GetUrl());

			DownloadManager.DownloadCallback callback = (www) => {
				StorageManager.SaveDownloadedEquation(www, formula);

				if (!m_DownloadFeedback.Somar()) {
					IniciarDownloads ();
				} else {
//					Debug.Log ("Download completo");
					m_InitialController.Ativar ();
				}
			};
			DownloadManager.Download (formula.GetUrl(), callback);

		}

	}
		
}