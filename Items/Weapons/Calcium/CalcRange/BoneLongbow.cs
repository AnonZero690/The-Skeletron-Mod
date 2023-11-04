using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcRangeProj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    public class BoneLongbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 2;
            Item.damage = 64;
            Item.knockBack = 2f;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.shootSpeed = 120f;
            Item.autoReuse = false;
            Item.ammo = AmmoID.Arrow;
            Item.noMelee = true;
            Item.ArmorPenetration = 2;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.maxStack = 1;
            Item.crit = 15;
            Item.UseSound = SoundID.Item5;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.noUseGraphic = false;
            Item.useTurn = true;
        }
        private bool isCharging = false;
        private int chargeTimer = 0;
        private int projectiles = 1;
        public override void HoldItem(Player player)
        {
           if (Main.mouseLeft)
            {
                isCharging = true;
                chargeTimer++;
           }
            else if(isCharging)
            {
                isCharging = false;
                int damage = chargeTimer / 2;
                if (damage > 100)
                {
                    damage = 100;
                }
                projectiles = 1 + chargeTimer / 300;
                chargeTimer = 0;
                int projType = ModContent.ProjectileType<SharpenedBoneProjectile>();
                float knockback = Item.knockBack;

                

                float chargeSpeed = 10f; // Adjust the charge speed as needed
                Vector2 velocity = Main.MouseWorld - player.Center; // Direction towards the cursor
                velocity.Normalize(); // Normalize to get a unit vector
                velocity *= chargeSpeed;
                for (int i = 0; i < projectiles; i++)
                {
                    Vector2 vec = velocity.Vector2Evenly(projectiles, 40, i);
                    Projectile.NewProjectile(null, player.Center, vec, projType, damage, knockback);
                }

                    
            }
        }

    }
}
