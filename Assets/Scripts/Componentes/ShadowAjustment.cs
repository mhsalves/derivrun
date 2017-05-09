using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LayoutsComponents {

	[RequireComponent(typeof (Shadow))]
	[RequireComponent(typeof (RectTransform))]
	[ExecuteInEditMode]
	public class ShadowAjustment : MonoBehaviour {

		public enum HDirection : int {
			DIREITA = 1, ESQUERDA = -1
		}

		public enum VDirection : int {
			CIMA = 1, BAIXO = -1
		}

		[Range(0, 1)] [SerializeField] private float m_PercentHorizontal;
		[Range(0, 1)] [SerializeField] private float m_PercentVertical;

		[SerializeField] private HDirection d_Horizontal = HDirection.DIREITA;
		[SerializeField] private VDirection d_Vertical = VDirection.BAIXO;

		void OnRenderObject () {
			
			var shadow = GetComponent<Shadow> ();
			var rt = GetComponent<RectTransform> ();

			shadow.effectDistance = Vector2.zero;

			var maxDistH = rt.rect.width * 0.1f;
			var maxDistV = rt.rect.width * 0.1f;

			float dh = (float) d_Horizontal;
			float dv = (float) d_Vertical;

			var d_Hor = (m_PercentHorizontal == 0) ? 0 : maxDistH * m_PercentHorizontal * dh;
			var d_Ver = (m_PercentVertical == 0) ? 0 : maxDistV * m_PercentVertical * dv;

			shadow.effectDistance = new Vector2 (d_Hor, d_Ver);

		}

	}

}