using UnityEngine;

public class IDamageMultiplier : ICommand
{
    Bullet bullets;
    int damageMultiplier;
    public IDamageMultiplier(Bullet bullet)
    {
        this.bullets = bullet;
    }

    public void Execute()
    {
        bullets.AddDamage(damageMultiplier);
    }

    public void Undo()
    {

    }
}
