using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Accessories.PendantTree
{
    internal class SkullNecklace : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 19;
            Item.value = 12000;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.defense = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.04f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 4f;

            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CranialPendant>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 13);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}