using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;
using TheSkeletronMod.projectiles.Calcprojs.CalcRangeProj;
using TheSkeletronMod.Items.Ammo;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;
using TheSkeletronMod.projectiles.Calcprojs.CalcMageproj;
using System.Security.Cryptography;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    public class Miniskull : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 22;
            Item.width = 7;
            Item.damage = 10;
            Item.knockBack = 1;
            
            Item.DefaultToRangedWeapon(ModContent.ProjectileType<BoneFragmentsProjectile>(), AmmoID.Bullet,10, 20, true);

    
            Item.value = 10000;
            Item.crit = 5;
            Item.scale = 0.2f;
            Item.UseSound = SoundID.Item5;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            int randomNumber = Main.rand.Next(1, 4);
            if (randomNumber == 2)
            {
                type = ModContent.ProjectileType<SharpenedBoneProjectile>();
                damage += 2;
            }else if (randomNumber == 3)
            {
                type = ModContent.ProjectileType<ClonedSkull>();

                damage += 10;
            }
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
            position = position.PositionOFFSET(velocity, 50);
        }
    }
}
