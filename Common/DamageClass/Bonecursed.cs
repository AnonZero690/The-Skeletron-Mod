
using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Common.DamageClass
{
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
        public override bool UseStandardCritCalcs => true;
    }
}