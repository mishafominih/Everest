using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    // Start is called before the first frame update
    public float energy;
    public Slider slider;

    void Start()
    {
        slider.value = energy;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
