using Terraria.ModLoader;

namespace TheSkeletronMod.Common.DamageClasses
{
    public class Bonecursed : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                knockbackInheritance: 0f);
        }
        public override bool UseStandardCritCalcs => true;
    }
}