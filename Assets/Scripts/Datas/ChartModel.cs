using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartModel {

	static readonly string url_Chart = "http://chart.apis.google.com/chart?";
	static readonly string p_ImageType = "&cht=";
	static readonly string p_Background = "&chf=";
	static readonly string p_Size = "&chs=";
	static readonly string p_Formula = "chl=";

	public static readonly int v_SizeWidth = 512;
	public static readonly int v_SizeHeight = 192;

	string m_ImageTypeValue = "tx";
	string m_BackgroundValue = "bg,s,0000EF00";
	string m_SizeValue = string.Format("{0}", ChartModel.v_SizeHeight);
	string m_Formula;

	public ChartModel(string formula) {
		this.m_Formula = formula;
	}

	public string GetUrl() {
		return url_Chart + p_Formula + WWW.EscapeURL(m_Formula) + p_ImageType + m_ImageTypeValue + p_Background + m_BackgroundValue + p_Size + m_SizeValue;
	}

}
