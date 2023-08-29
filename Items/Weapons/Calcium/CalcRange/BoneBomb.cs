using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    internal class BoneBomb : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultRange(30, 36, 34, 5f, 40, 40, ItemUseStyleID.Swing, ModContent.ProjectileType<BoneBombProjectile>(), 7, true);
            Item.DamageType = DamageClass.Ranged;
            Item.noUseGraphic = true;
        }
    }
    public class BoneBombProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<BoneBomb>();
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 210;
            Projectile.penetrate = 1;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.Center, 0, 0, DustID.Bone);
            if (Projectile.velocity != Vector2.Zero)
            {
                Projectile.rotation += MathHelper.ToRadians(Projectile.velocity.Length() * 2.5f) * (Projectile.velocity.X > 0 ? 1 : -1);
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] <= 20)
            {
                return;
            }
            if (Projectile.velocity.Y < 23)
            {
                Projectile.velocity.Y += .4f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if(Projectile.velocity.X != oldVelocity.X)
                Projectile.velocity.X = -oldVelocity.X;
            Projectile.velocity.Y = -oldVelocity.Y * .8f;
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            Projectile.Center.LookForHostileNPC(out List<NPC> npclist, 200f);
            int direction;
            foreach (NPC npc in npclist)
            {
                npc.StrikeNPC(npc.CalculateHitInfo(Projectile.damage,1));
                player.addDPS(Projectile.damage);
            }
            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = Projectile.velocity.Vector2Evenly(10, 360, i);
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, vel.LimitingVelocity(5f), ProjectileID.Bone, (int)(Projectile.damage * .65f), Projectile.knockBack, Projectile.owner);
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].penetrate = -1;
                Main.projectile[proj].maxPenetrate = -1;
            }
        }
    }
}