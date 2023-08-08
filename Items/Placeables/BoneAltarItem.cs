using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Materials;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Placeables
{


    public class BoneAltarItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;

            Item.maxStack = 9999;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<BoneAltar>();

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 5);
            recipe.AddIngredient(ItemID.Cobweb, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }


}