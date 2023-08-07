using Terraria.ModLoader;

namespace SkellyModYT.Content.DamageClasses
{
    public class CartilageDMGClass : DamageClass
    {
        public override bool UseStandardCritCalcs => true;

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;
            return new StatInheritanceData(damageInheritance: 0f, critChanceInheritance: 0f, attackSpeedInheritance: 0f, armorPenInheritance: 0f, knockbackInheritance: 0f);
        }

    }
}