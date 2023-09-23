using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Weapons.Melee;
using TheSkeletronMod.projectiles.Calcprojs.CalcMageproj;

namespace TheSkeletronMod.Items.Weapons.Calcium.MilkMage
{
    public class BoneTome : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.width = 20;
            Item.height = 20;
            Item.noMelee = true;
            Item.useAnimation = 120;
            Item.useTime = 120;

        }
        bool HasBones = false;
        int waitTime = 120;
        const int waitTimeMax = 120;
        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem == Item)
            {
                if (HasBones == false)
                {
                    if (waitTime == 0)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_None(), new Microsoft.Xna.Framework.Vector2(player.position.X, player.position.Y), new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<CircleBone>(), 10, 0);
                        HasBones = true;
                        waitTime = waitTimeMax;
                    }else
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
