using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controladores {

	public class LifeController : MonoBehaviour {

		public int vidas = LifeController.minVidas;
		public int vidasCorrente = LifeController.minVidas;
		public static int minVidas = 1;
		public static int maxVidas = 10;

		public int GetVidas () {
			return vidas;
		}

		public int GetVidasCorrente () {
			return vidasCorrente;
		}

		// Use this for initialization
		void Start () {
			DontDestroyOnLoad (gameObject);

		}

		public void IniciarCom( int vidas ) {
			this.vidas = (vidas < minVidas) ? minVidas : (vidas > maxVidas) ? maxVidas : vidas;
			this.vidasCorrente = this.vidas;
		}

		public bool PerderVida () {
			this.vidasCorrente--;

			if (this.vidasCorrente <= 0) {
				return true;	
			} else {
				return false;
			}

		}
	}

}