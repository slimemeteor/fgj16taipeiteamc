using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChickPoint : MonoBehaviour {
	public Slider m_Slider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	//ChickPointAdd的UserFounction是1增加
	void ChickPointAdd(string UserFounction){
		if (m_Slider.value < 6 && UserFounction == "1") {
				m_Slider.value += 1;
			} else {
			Debug.Log ("失敗");
			}
	}
}
