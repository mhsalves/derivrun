using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (HorizontalOrVerticalLayoutGroup))]
[RequireComponent(typeof (RectTransform))]
[ExecuteInEditMode]
public class SpacingLayout : MonoBehaviour {

	[SerializeField] private int m_QuantidadeItens;
	[Range(0, 1)][SerializeField] private float m_Percent = .1f;

	// Use this for initialization
	void OnRenderObject () {
		var hovlg = GetComponent<HorizontalOrVerticalLayoutGroup> ();
		var rt = GetComponent<RectTransform> ();

		hovlg.spacing = rt.rect.width/m_QuantidadeItens * m_Percent;

	}

}
