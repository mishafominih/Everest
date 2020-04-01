using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyAndOxygenScript : MonoBehaviour
{
	GameObject canvas;
	[SerializeField] float oxygen = 100;
	[SerializeField] float energy = 100;
	public Energy Energy;
	public Oxygen Oxygen;

	void Start()
    {
		Energy = new Energy(energy);
		Oxygen = new Oxygen(oxygen);
		canvas = GetComponent<Instantiater>().Canvas;
    }

	void Update()
	{
		var sliders = GetComponent<Instantiater>().Canvas.GetComponentsInChildren<Slider>();
		if (sliders[0].tag == "Energy")
			Energy.UpdateSlider(sliders[0]);
		else
			Energy.UpdateSlider(sliders[1]);
		if (sliders[0].tag == "Oxygen")
			Oxygen.UpdateSlider(sliders[0]);
		else
			Oxygen.UpdateSlider(sliders[1]);
	}
}
