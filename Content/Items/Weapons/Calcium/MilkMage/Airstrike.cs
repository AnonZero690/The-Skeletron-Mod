using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.MilkMage
{
    public class Airstrike : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.damage = 20;
            Item.knockBack = 2f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<AirstrikeBone>();
            Item.shootSpeed = 3;
            Item.autoReuse = true;
            Item.mana = 3;
            Item.value = 10000;
            Item.crit = 5;
            Item.noUseGraphic = false;
            //Item.scale = 0.1f;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item8;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 1;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -1);
        }
        //public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        //{
        //    Vector2 newPos = new Vector2(position.X - 3, position.Y + 4);
        //    base.ModifyShootStats(player, ref newPos, ref velocity, ref type, ref damage, ref knockback);
        //    position = position.PositionOFFSET(velocity, 50);
        //}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.MouseWorld;
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            // Loop these functions 3 times.
            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }
    }
}
