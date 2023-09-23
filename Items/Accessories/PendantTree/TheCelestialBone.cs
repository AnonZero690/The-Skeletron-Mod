using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Tiles;
using Terraria.DataStructures;

namespace TheSkeletronMod.Items.Accessories.PendantTree
{
    internal class TheCelestialBone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 14));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.scale = 1.5f;
            Item.width = 66;
            Item.height = 94;
            Item.value = 69000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.defense = 4;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.25f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 20;
            player.endurance += 0.12f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 1);
            recipe.AddIngredient(ItemID.FragmentNebula, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 1);
            recipe.AddIngredient(ItemID.FragmentStardust, 1);
            recipe.AddIngredient(ModContent.ItemType<AncientCartilageTablet>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}