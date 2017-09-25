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
			Debug.Log (formula.GetUrl());

			DownloadManager.DownloadCallback callback = (www) => {
				StorageManager.SaveDownloadedEquation(www, formula);

				if (!m_DownloadFeedback.Somar()) {
					IniciarDownloads ();
				} else {
					print ("Download completo");
					m_InitialController.Ativar ();
				}
			};
			DownloadManager.Download (formula.GetUrl(), callback);

		}

		public static List<Formula> GetBaseList() {
			StorageManager.LoadJSON ();
			List<Formula> list = new List<Formula> ();

			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 2));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 3, true));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 4));

			return list;
		}

	}
		
}