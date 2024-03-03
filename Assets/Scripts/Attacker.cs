using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackValue = 10f;
    [SerializeField] private float _cooldown = 3f;

    public event Action<bool> Attacking;

    private Coroutine _coroutine;

    public bool IsAttack {  get; private set; }

    protected void TryAttack(Health health)
    {
        if (IsAttack)
        {
            return;
        }

        health.Died += StopAttack;

        IsAttack = true;
        Attacking?.Invoke(true);
        _coroutine = StartCoroutine(Attack(health));
    }

    protected void StopAttack()
    {
        if (IsAttack == false)
        {
            return;
        }

        IsAttack = false;
        Attacking?.Invoke(false);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Attack(Health health)
    {
        var wait = new WaitForSeconds(_cooldown);

        while (IsAttack)
        {
            health.TakeDamage(_attackValue);
            yield return wait;
        }
    }
}
