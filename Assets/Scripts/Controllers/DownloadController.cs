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
//			this.formulas = StorageManager.LoadJSON ();
			this.formulas = GetBaseList ();

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
					Debug.Log ("Download completo");
					m_InitialController.Ativar ();
				}
			};
			DownloadManager.Download (formula.GetUrl(), callback);

		}

		public static List<Formula> GetBaseList() {
			List<Formula> list = new List<Formula> ();

			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{3}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{4}}\;dx=\sqrt{\pi}", 2));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{5}}\;dx=\sqrt{\pi}", 3, true));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{6}}\;dx=\sqrt{\pi}", 4));

			list.Add (new Formula (2, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{7}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (2, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{8}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (2, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{9}}\;dx=\sqrt{\pi}", 2, true));
			list.Add (new Formula (2, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{10}}\;dx=\sqrt{\pi}", 3));
			list.Add (new Formula (2, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{11}}\;dx=\sqrt{\pi}", 4));

			list.Add (new Formula (3, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{12}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (3, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{13}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (3, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{14}}\;dx=\sqrt{\pi}", 2));
			list.Add (new Formula (3, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{15}}\;dx=\sqrt{\pi}", 3, false));
			list.Add (new Formula (3, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{16}}\;dx=\sqrt{\pi}", 4));

			list.Add (new Formula (4, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{17}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (4, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{18}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (4, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{19}}\;dx=\sqrt{\pi}", 2, true));
			list.Add (new Formula (4, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{20}}\;dx=\sqrt{\pi}", 3));
			list.Add (new Formula (4, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{21}}\;dx=\sqrt{\pi}", 4));

			return list;
		}

	}
		
}