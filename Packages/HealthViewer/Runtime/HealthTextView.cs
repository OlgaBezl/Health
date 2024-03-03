using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextView : HealthView
{    
    private TextMeshProUGUI _text;
    
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Health.Changed += UpdateView;
        UpdateView(Health.CurrentHealth);
    }

    protected override void UpdateView(float currentHealth)
    {
        _text.text = currentHealth + " / " + Health.MaxHealth;
    }
}
