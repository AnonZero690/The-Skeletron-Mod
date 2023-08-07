using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheSkeletronMod.Items.Weapons.Ranged
{
    public class BoneCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 3;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.useTime = 120;
            Item.width = 10;
            Item.height = 10;
            Item.useAnimation = 120;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<SharpenedBoneProjectile>();
            Item.shootSpeed = 10f;
            Item.autoReuse = false;
            Item.useAnimation = 20;
            Item.crit = 75;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Stake;
            Item.UseSound = SoundID.Item5;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }
        int timesShot = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player == null) return false;
            if (source == null) return false;
            

            if (timesShot == 4)
            {
                int spreadShot = 0;
                for (int i = 0; i < 8; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians(40 - (10 * spreadShot)));
                    Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                    spreadShot++;
                }

                timesShot = 0;
            }
            else
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                timesShot++;
            }

            

            return false;
        }
    }
}
