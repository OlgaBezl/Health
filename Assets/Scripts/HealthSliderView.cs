using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderView : HealthView
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = Health.MaxHealth;
        _slider.value = Health.CurrentHealth;
        Health.Changed += UpdateView;
    }

    protected override void UpdateView(float currentHealth)
    {
        _slider.value = currentHealth;
    }
}
