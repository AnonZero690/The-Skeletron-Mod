
using Terraria;
using Terraria.ModLoader;

public class Bonecursed : DamageClass
{
    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
    {
        if (damageClass == DamageClass.Generic)
            return StatInheritanceData.Full;

        return new StatInheritanceData(
            damageInheritance: 0f,
            critChanceInheritance: 0f,
            attackSpeedInheritance: 0f,
            knockbackInheritance: 0f);
    }
    public override void SetDefaultStats(Player player)
    {
        player.GetAttackSpeed<Bonecursed>() += 4;
        player.GetArmorPenetration<Bonecursed>() += 0.5f;
        player.GetDamage<Bonecursed>() += 0.2f;
    }
    public override bool UseStandardCritCalcs => true;
}