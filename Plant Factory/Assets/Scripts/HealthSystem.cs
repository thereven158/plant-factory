
public class HealthSystem
{
    private double health;
    private double healthMax;

    public HealthSystem (double healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;

    }

    public double GetHealth ()
    {
        return health;
    }

    public float GetHealthPercent ()
    {
        return (float)health / (float)healthMax;
    }

    public void Heal (double healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
    }

    public void Damaged (double damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
    }
}
