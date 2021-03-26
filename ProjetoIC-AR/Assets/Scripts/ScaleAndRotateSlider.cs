using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotateSlider : MonoBehaviour
{

    private Slider scaleSlider;
    private Slider rotateSlider;
    public float ScaleMinValue;
    public float ScaleMaxValue;
    public float RotateMinValue;
    public float RotateMaxValue;




    // Start is called before the first frame update
    void Start()
    {
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.minValue = ScaleMinValue;
        scaleSlider.maxValue = ScaleMaxValue;

        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = RotateMinValue;
        rotateSlider.maxValue = RotateMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

    }

    void Update()
    {
        
    }

    void ScaleSliderUpdate(float value) {
        transform.localScale = new Vector3(value, value, value);
    }
    void RotateSliderUpdate(float value) {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, value, transform.rotation.z);
    }
}
