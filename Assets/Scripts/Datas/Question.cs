using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Models {
	
	public class Question {

		public struct Resposta {
			public Sprite sprite;
			public bool is_correta;

			public Resposta (Sprite sprite) {
				this.sprite = sprite;
				this.is_correta = false;
			}

			public Resposta (Sprite sprite, bool is_correta) {
				this.sprite = sprite;
				this.is_correta = is_correta;
			}
		}

		public Sprite enunciado;
		public Resposta resposta_1;
		public Resposta resposta_2;
		public Resposta resposta_3;
		public Resposta resposta_4;

		public List<Resposta> respostas;

		public Question(byte[] e, byte[] r1, byte[] r2, byte[] r3, byte[] r4, string correta) {
			
			this.enunciado = ConvertBytesToSprite (e);
			this.resposta_1 = new Resposta(ConvertBytesToSprite (r1), (correta == "1"));
			this.resposta_2 = new Resposta(ConvertBytesToSprite (r2), (correta == "2"));
			this.resposta_3 = new Resposta(ConvertBytesToSprite (r3), (correta == "3"));
			this.resposta_4 = new Resposta(ConvertBytesToSprite (r4), (correta == "4"));

			this.LoadRespostaList ();

		}

		private void LoadRespostaList() {
			this.respostas = new List<Resposta> ();
			this.respostas.Add (this.resposta_1);
			this.respostas.Add (this.resposta_2);
			this.respostas.Add (this.resposta_3);
			this.respostas.Add (this.resposta_4);
		}

		static Sprite ConvertBytesToSprite ( byte[] bytes ) {
			Texture2D tex = new Texture2D(1, 1);
			tex.LoadImage (bytes);

			Sprite sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.5f));

			return sprite;
		}

	}

}