using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Buffs;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Armor.AncientBoneArmour
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientBoneHelmet : ModItem
    {
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.04f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 2;
        }
        public override void SetDefaults()
        {
            Item.value = 6000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 2;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 15);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AncientBoneChestplate>() && legs.type == ModContent.ItemType<AncientBoneLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "2 defense\nSummons a boney circle around you, that inflicts boned debuff on enemies in range.";
            player.statDefense += 2;
            player.AddBuff(ModContent.BuffType<AncientBoneBuff>(), 1);
        }
    }
}
