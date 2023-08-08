using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Weapons.Calcium
{
    public class ClusterboneShotgun : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultRange(56, 2, 14, 2f, 22, 22, ItemUseStyleID.Shoot, ModContent.ProjectileType<BoneFragmentsProjectile>(), 20f, true, AmmoID.Stake);
            Item.value = 60;
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
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }
       // public override Vector2? HoldoutOffset()
        //{
        //    return new Vector2(-6,0);
        //}
        //public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        //{
        //    base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
        //    position = position.PositionOFFSET(velocity, 50);
        //}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
        for (int i = 0; i < 3; i++)
            {
                Vector2 vec = velocity.Vector2Evenly(3, 30, i);
                Projectile.NewProjectile(source, position, vec, type, damage, knockback, player.whoAmI, 0, 1);
            }
            return true;
        }
    }
}
