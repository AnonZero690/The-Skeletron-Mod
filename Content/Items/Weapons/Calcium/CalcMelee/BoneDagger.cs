using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    public class BoneDagger : ModItem
    {
        public override void SetDefaults()
        {
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.reuseDelay = 1;

            Item.useStyle = 1;
            Item.width = 16;
            Item.height = 16;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.damage = 25;
            Item.knockBack = 3;

            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Gray;
            Item.shoot = ModContent.ProjectileType<BoneHeld>();
            Item.shootSpeed = 20f;

            Item.autoReuse = false;
            Item.crit = 10;
            Item.noMelee = true;
            Item.value = Item.buyPrice(gold: 0, silver: 43);
            Item.noUseGraphic = true;
            Item.channel = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<BoneHeld>();
                Item.channel = false;
                Item.useStyle = ItemUseStyleID.Swing;
                return player.ownedProjectileCounts[ModContent.ProjectileType<BoneDaggerProjectile>()] < 1;
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<BoneSwingHeld>();
                Item.channel = true;
                return player.ownedProjectileCounts[ModContent.ProjectileType<BoneSwingHeld>()] < 1;
            }
        }
        public override bool MeleePrefix()
        {
            return true;
        }
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if(player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(source, position, velocity * 7.5f, ModContent.ProjectileType<BoneDaggerProjectile>(), damage, knockback, player.whoAmI, 1);
				return false;
			}
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }*/
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 14);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}
