namespace MLBB;

public sealed class Belerick
{
    public const int ReflectionPercentage = 100;

    /// <summary>
    /// Reflects 100% of the incoming damage to the attacker.
    /// </summary>
    public DamageResult ReflectDamage(double incomingDamage)
    {
        if (incomingDamage < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(incomingDamage),
                "Incoming damage cannot be negative.");
        }

        var reflectedDamage = incomingDamage * ReflectionPercentage / 100d;

        return new DamageResult
        {
            IncomingDamage = incomingDamage,
            ReflectedDamage = reflectedDamage,
            FinalDamageTaken = 0
        };
    }
}

public readonly record struct DamageResult(
    double IncomingDamage,
    double ReflectedDamage,
    double FinalDamageTaken);
