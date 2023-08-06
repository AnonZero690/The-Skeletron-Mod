using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheSkeletronMod.Assets.Items.Weapons.Melee
{
	public class BoneDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 23;
			Item.width = 10;
			Item.height = 10;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3;
			Item.value = 60;
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = false;
			Item.useAnimation = 20;
			Item.crit = 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock,27);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
