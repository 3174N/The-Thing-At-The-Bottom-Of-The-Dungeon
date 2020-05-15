using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    /// <summary>
    /// Start called before the first frame
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// Setting the maximum of the stamina bar
    /// </summary>
    /// <param name="stamina"></param>
    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    /// <summary>
    /// Changing the current stamina
    /// </summary>
    /// <param name="stamina"></param>
    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }
}
