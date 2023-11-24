using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcRangeProj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcRange
{
    public class BoneCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemSetDefault(56, 2, 14, 2f, 22, 22, ItemUseStyleID.Shoot, true);
            Item.DefaultToRangedWeapon(ModContent.ProjectileType<SharpenedBoneProjectile>(), AmmoID.Stake, 22, 20f, true);
            Item.value = 10000;
            Item.crit = 5;
            Item.UseSound = SoundID.Item5;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
            position = position.PositionOFFSET(velocity, 50);
        }
        int timesShot = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (timesShot == 5)
            {
                int spreadShot = 0;
                for (int i = 0; i < 6; i++)
                {
                    Vector2 vec = velocity.Vector2Evenly(6, 40, i);
                    Projectile.NewProjectile(source, position, vec, type, damage, knockback, player.whoAmI, 0, 1);
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
