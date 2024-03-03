using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothSliderView : HealthView
{
    [SerializeField] private float _smoothDescreaseDuration = 0.5f;
    
    private Slider _smoothSlider;

    private void Start()
    {
        _smoothSlider = GetComponent<Slider>();
        _smoothSlider.maxValue = Health.MaxHealth;
        _smoothSlider.value = Health.CurrentHealth;
        Health.Changed += UpdateView;
    }

    protected override void UpdateView(float currentHealth)
    {
        StartCoroutine(ChangeHealthSmoothly(currentHealth));
    }

    private IEnumerator ChangeHealthSmoothly(float target)
    {
        float elapsedTime = 0f;
        float previousValue = _smoothSlider.value;

        while (elapsedTime < _smoothDescreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDescreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValue, target, normalizedPosition);
            _smoothSlider.value = intermediateValue;
            yield return null;
        }
    }
}
