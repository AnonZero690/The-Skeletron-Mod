using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Accessories.PendantTree
{
    public class AncientCartilageTablet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 14));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 60;
            Item.value = 60000;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Lighting.AddLight(Item.position, r: 112f, 39f, b: 41f);
            Item.defense = 5;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.15f;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 20f;
            player.endurance += 0.08f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SolarTablet, 1);
            recipe.AddIngredient(ItemID.EyeoftheGolem, 1);
            recipe.AddIngredient(ModContent.ItemType<MechanicalSkull>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}