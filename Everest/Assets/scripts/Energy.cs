using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
	float energy;

	public Energy(float energy)
	{
		this.energy = energy;
	}

    public void UpdateEnergy(float dEnergy)
	{
		energy += dEnergy;
	}

	public void UpdateSlider(Slider slider)
	{
		slider.value = energy;
	}
}
