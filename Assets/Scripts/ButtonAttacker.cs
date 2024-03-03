using UnityEngine;

public class ButtonAttacker : Attacker
{
    [SerializeField] private Health _health;

    public void Attack()
    {
        TryAttack(_health);
        StopAttack();
    }

}
