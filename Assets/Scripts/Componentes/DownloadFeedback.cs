using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DownloadManager {
	
	public class DownloadFeedback : MonoBehaviour {

		private static readonly string S_Downloading = "Baixando...";
		private static readonly string S_Complete = "Completo!";
		private static readonly string S_Passed = "Passado...";

		private int _counter = 0;
		public int counter {
			get { return _counter; }
		}
		public int max {
			get { 
				return (int) m_Slider.maxValue;
			}
		}

		[SerializeField] private Text m_Text;
		[SerializeField] private Slider m_Slider;

		public void Init(int max) {
			this._counter = 0;
			this.m_Slider.maxValue = max;
			this.UpdateView ();
		}

		public bool Somar() {
			_counter++;
			bool check = (_counter == max);
			this.UpdateView ( (check) ? S_Complete : GetDownloadingString() );
			return check;
		}

		public bool Pular() {
			_counter++;
			bool check = (_counter == max);
			this.UpdateView ( (check) ? S_Complete : S_Passed );
			return check;
		}

		private void UpdateView () {
			UpdateView (GetDownloadingString());
		}

		private void UpdateView (string message) {
			m_Slider.value = _counter;
			m_Text.text = message;
		}

		private string GetDownloadingString() {
			return DownloadFeedback.S_Downloading + string.Format ("({0}/{1})", _counter, max);
		}
	}

}
