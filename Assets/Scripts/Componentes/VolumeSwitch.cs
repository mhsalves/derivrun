using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controladores;

public class VolumeSwitch : MonoBehaviour {

	private BGMController m_BGMController;

	[SerializeField] private Slider m_Slider;
	[SerializeField] private Text m_Value;
	[SerializeField] private Toggle m_Toggle;

	public bool m_Mudo {
		set { 
			m_BGMController.Mutar (!value);
		}
	}

	public float m_Volume {
		set { 
			m_BGMController.MudarVolume (value);
			m_Value.text = VolumeFormat(value);
		}
	}

	// Use this for initialization
	void Awake () {
		m_BGMController = GameObject.FindGameObjectWithTag ("BGMController").GetComponent<BGMController> ();

	}

	void Start () {
		m_Slider.value = m_BGMController.GetVolume ();
		m_Value.text = VolumeFormat(m_Slider.value);
		m_Toggle.isOn = m_BGMController.GetMute ();

	}

	private string VolumeFormat( float value ) {
		var v = value * 100;
		v = Mathf.CeilToInt (v);
		return v + "%";
	}

}
