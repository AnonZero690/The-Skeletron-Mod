using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Weapons.Ranged
{
    public class BoneCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultRange(56, 2, 3, 2f, 12, 12, ItemUseStyleID.Shoot, ModContent.ProjectileType<SharpenedBoneProjectile>(), 15f, false, AmmoID.Stake);
            Item.value = 60;
            Item.crit = 75;
            Item.UseSound = SoundID.Item5;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
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
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
            position = position.PositionOFFSET(velocity, 50);
        }
        int timesShot = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
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
                return false;
            }
            timesShot++;
            return true;
        }
    }
}
