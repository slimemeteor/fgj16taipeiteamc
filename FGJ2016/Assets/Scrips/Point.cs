using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Point : MonoBehaviour {

	public static Slider slider;

	void Start()
	{
		slider = this.gameObject.GetComponent<Slider>();
	}

	public static void addPoint()
	{
		slider.value += 1f;
	}
}
