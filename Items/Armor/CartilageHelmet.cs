using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;
using TheSkeletronMod.Items.Materials;
using TheSkeletronMod.Buffs;

namespace TheSkeletronMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CartilageHelmet : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.02f;
        }
        public override void SetDefaults()
        { 
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;
            
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 10);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return (body.type == ModContent.ItemType<CartilageChestplate>() && legs.type == ModContent.ItemType<CartilageLeggings>());
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage<Bonecursed>() += 0.1f;
            player.AddBuff(ModContent.BuffType<CartilageBuff>(), 1);
            player.setBonus = "Summons a skull above your head to launch projectiles at your enemies";
        }
    }
}
