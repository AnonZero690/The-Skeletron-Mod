using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Accessories.PendantTree
{
    internal class UndeadToken : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 19;
            Item.height = 20;
            Item.value = 40000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.17f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 8f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BoneLocket>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BoneEmblem>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}
