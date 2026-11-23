namespace MLBB;

public sealed class Tenacity
{
    public const int DamageBlockPercentage = 100;
    public const int DamageReflectionPercentage = 100;

    /// <summary>
    /// Permanently blocks and reflects all incoming damage.
    /// </summary>
    public DamageResult ApplyTenacity(double incomingDamage)
    {
        if (incomingDamage < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(incomingDamage),
                "Incoming damage cannot be negative.");
        }

        var reflectedDamage = incomingDamage * DamageReflectionPercentage / 100d;

        return new DamageResult
        {
            IncomingDamage = incomingDamage,
            ReflectedDamage = reflectedDamage,
            FinalDamageTaken = incomingDamage * (1d - DamageBlockPercentage / 100d)
        };
    }
}

public readonly record struct DamageResult(
    double IncomingDamage,
    double ReflectedDamage,
    double FinalDamageTaken);
