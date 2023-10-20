using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.projectiles.Calcprojs.CalcMageproj;
using Terraria.ID;
using TheSkeletronMod.Items.Materials;

namespace TheSkeletronMod.Items.Weapons.Calcium.MilkMage
{
    public class BoneTome : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.width = 33;
            Item.height = 35;
            Item.noMelee = true;
            Item.useAnimation = 120;
            Item.useTime = 120;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 20);
            recipe.AddTile(TileID.Bookcases);
            recipe.Register();
        }
        bool HasBones = false;
        int waitTime = 120;
        const int waitTimeMax = 120;
        int rotAmt = 0;
        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem == Item)
            {
                if (HasBones == false)
                {
                    if (waitTime == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            int projectileIndex = Projectile.NewProjectile(Projectile.GetSource_None(), new Vector2(player.position.X, player.position.Y), new Vector2(0, 0), ModContent.ProjectileType<CircleBone>(), 10, 0,-1);
                            Projectile myProjectile = Main.projectile[projectileIndex];
                            myProjectile.ai[0] = rotAmt;
                            rotAmt += 90;
                            //myProjectile.rotation = MathHelper.ToRadians(rotAmt);
                            //player.Heal(1);
                        }
                        HasBones = true;
                        waitTime = waitTimeMax;
                        rotAmt = 0;
                    }
                    else
                    {
                        waitTime -= 1;
                    }
                }
            }
            else
            {
                HasBones = false;
                waitTime = waitTimeMax;
            }
        }
        
    } 
}
