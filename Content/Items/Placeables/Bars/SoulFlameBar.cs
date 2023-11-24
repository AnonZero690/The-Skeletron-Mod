using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Placeables.Bars
{
    internal class SoulFlameBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 8));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }

        public override void SetDefaults()
        {
            Item.width = 42; //width of frame table
            Item.height = 58; //height of 1 frame
            Item.value = 60000;
            Item.rare = ItemRarityID.Cyan;
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = false;
            Item.material = true;
            Item.maxStack = 999;


            //Item.accessory = true;
            //Lighting.AddLight(Item.position, r: 112f, 39f, b: 41f);
            //Item.defense = 5;
        }

        //public override void AddRecipes()
        //{
            //Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(ModContent.ItemType<CalciumOre>(), 3);
            //recipe.AddTile(TileID.Furnaces);
            //recipe.Register();
        //}

    }
}
