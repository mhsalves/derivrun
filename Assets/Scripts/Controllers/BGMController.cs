using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controladores {
	
	[RequireComponent(typeof (AudioSource))]
	public class BGMController : MonoBehaviour {

		private AudioSource m_AudioSource;

		[Range(0f, 1f)] [SerializeField] private float m_VolumeInicial = 0.2f;

		void Awake () {
			this.m_AudioSource = GetComponent<AudioSource> ();

		}

		void Start() {
			DontDestroyOnLoad (transform.gameObject);

			this.m_AudioSource.volume = m_VolumeInicial;

		}

		public void MudarVolume ( float volume ) {
			this.m_AudioSource.volume = Mathf.Clamp(volume, 0f, 1f) ;
		}

		public void Mutar( bool mutar ) {
			this.m_AudioSource.mute = mutar;
		}


	}

}