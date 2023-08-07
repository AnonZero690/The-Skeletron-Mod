using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.projectiles;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Weapons.Calcium
{
	public class BoneDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.ItemSetDefault(50, 10, 16, 6f, 20, 20, ItemUseStyleID.Shoot, true);
			Item.ItemSetDefaultSpear(ModContent.ProjectileType<BoneDaggerProjectile>(), 2f);

			Item.crit = 10;
			Item.value = 60;
			Item.rare = ItemRarityID.Green;
			Item.DamageType = ModContent.GetInstance<Bonecursed>();
		}
        public override bool CanUseItem(Player player)
        {
			if (player.altFunctionUse == 2)
				Item.useStyle = ItemUseStyleID.Swing;
			else 
				Item.useStyle = ItemUseStyleID.Shoot;
            return base.CanUseItem(player);
        }
        public override bool MeleePrefix()
        {
			return true; // allows it to have melee prefixes
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if(player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(source, position, velocity * 7.5f, type, damage, knockback, player.whoAmI, 1);
				return false;
			}
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock,27);
			recipe.AddTile(ModContent.TileType<BoneAltar>());
			recipe.Register();
		}
		
	}
}
