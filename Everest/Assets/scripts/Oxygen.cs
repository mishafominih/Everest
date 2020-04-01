using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
	float oxygen;

	public Oxygen(float oxygen)
	{
		this.oxygen = oxygen;
	}

    public void UpdateOxygen(float dOxygen) 
	{
		oxygen += dOxygen;
	}

	public void UpdateSlider(Slider slider)
	{
		slider.value = oxygen;
	}
}
