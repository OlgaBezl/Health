using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [field: SerializeField] public Health Health { get; private set; }

    private void Start()
    {
        Health.Changed += UpdateView;
    }

    private void OnDisable()
    {
        Health.Changed -= UpdateView;
    }

    protected abstract void UpdateView(float currentHealth);

}
