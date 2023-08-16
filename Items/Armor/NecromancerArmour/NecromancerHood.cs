using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;
using TheSkeletronMod.Items.Materials;

namespace TheSkeletronMod.Items.Armor.NecromancerArmour
{
    [AutoloadEquip(EquipType.Body)]
    public class NecromancerRobe : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.14f;
            player.manaCost -= 0.2f;
        }
        public override void SetDefaults()
        {
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 9;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 5);   
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

    }
}
