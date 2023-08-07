using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Projectiles;
using TheSkeletronMod.Common.DamageClasses;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace TheSkeletronMod.Items.Weapons.Melee
{
	public class BoneDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.useTime = 140;
			Item.width = 50;
			Item.height = 50;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.knockBack = 3;
			Item.value = 60;
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = false;
			Item.crit = 10;
			Item.useLimitPerAnimation = 1;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
        public override void RightClick(Player player)
        {
            Vector2 direction = (player.Center - Main.MouseWorld).SafeNormalize(Vector2.UnitX);
            Projectile.NewProjectile(Item.GetSource_FromThis(), player.position, direction * 13, ModContent.ProjectileType<BoneDaggerProjectile>(), Item.damage, 5f, player.whoAmI);
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
