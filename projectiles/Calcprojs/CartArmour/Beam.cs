
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Modplayer;

namespace TheSkeletronMod.projectiles.Calcprojs.CartArmour
{
    public class Beam : ModProjectile
    {
        private const float moving = 50f;

        Vector2 difference;

        public float setting
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item72);
        }


        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hide = true;
            Projectile.timeLeft = 10;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player p = Main.LocalPlayer;

            var texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            var spriteBatch = Main.spriteBatch;

            laser(spriteBatch, texture, new Vector2(p.GetModPlayer<SkullModplayer>().proj.position.X, p.GetModPlayer<SkullModplayer>().proj.position.Y),
                    Projectile.velocity, 1, Projectile.damage, -1.57f, 1f, 1800f, Color.White, 20);
            return false;
        }



        public void laser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 t, float state, int dmg, float rotation = 0f, float scale = 1f, float maximun = 1800f, Color col = default(Color), int transitional = 50)
        {
            float rotati = t.ToRotation() + rotation;

            for (float i = transitional; i <= setting; i += state)
            {
                Color c = Color.White;
                var origin = start + i * t;
                spriteBatch.Draw(texture, origin - Main.screenPosition,
                    new Rectangle(0, 26, 28, 26), i < transitional ? Color.Transparent : c, rotati,
                    new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
            }

            spriteBatch.Draw(texture, start + t * (transitional - state) - Main.screenPosition,
                new Rectangle(0, 0, 28, 26), Color.White, rotati, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);

            spriteBatch.Draw(texture, start + (setting + state) * t - Main.screenPosition,
                new Rectangle(0, 52, 28, 26), Color.White, rotati, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.GetModPlayer<SkullModplayer>().proj.Center,
                player.GetModPlayer<SkullModplayer>().proj.Center + unit * setting, 22, ref point);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 10;
        }

        

        public override void AI()
        {
            Projectile.tileCollide = false;
            Player player = Main.player[Projectile.owner];
            if (Projectile.timeLeft == 10)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    difference = player.GetModPlayer<SkullModplayer>().npc.Center - player.GetModPlayer<SkullModplayer>().proj.Center;
                    difference.Normalize();

                }
                
            }
            Projectile.velocity = difference;
            Projectile.direction = player.GetModPlayer<SkullModplayer>().npc.Center.X > player.GetModPlayer<SkullModplayer>().proj.Center.X ? 1 : -1;
            Projectile.netUpdate = true;
            int direct = Projectile.direction;
            player.ChangeDir(direct);
            player.heldProj = Projectile.whoAmI;
            laserloc(player);

            Projectile.position = player.GetModPlayer<SkullModplayer>().proj.Center + Projectile.velocity * moving;
        }

        private void laserloc(Player player)
        {
            for (setting = moving; setting <= 2200f; setting += 5f)
            {
            }
        }

        

        

        public override bool ShouldUpdatePosition() => false;
        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 t = Projectile.velocity;
            Utils.PlotTileLine(Projectile.Center, Projectile.Center + t * setting, (Projectile.width + 16) * Projectile.scale, DelegateMethods.CutTiles);
        }
    }
}
