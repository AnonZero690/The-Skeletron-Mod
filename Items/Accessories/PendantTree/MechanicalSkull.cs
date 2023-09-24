using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Accessories.PendantTree
{
    internal class MechanicalSkull : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 19;
                Item.height = 24;
            Item.value = 50000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.defense = 6;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.20f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 12f;
            player.endurance += 0.5f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFright, 8);
            recipe.AddIngredient(ItemID.SoulofSight, 8);
            recipe.AddIngredient(ItemID.SoulofMight, 8);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ModContent.ItemType<UndeadToken>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}
