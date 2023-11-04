using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheSkeletronMod.Common.DamageClasses;
using Microsoft.Xna.Framework;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneScytheP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 112;
            Projectile.height = 142;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 5;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 10f;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
        }

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 7;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public bool damageReduced = false;
        public override void AI()
        {
            if (Projectile.penetrate <= 0)
            {
                if (Projectile.timeLeft >= 20)
                {
                    Projectile.timeLeft = 20;
                }
                Projectile.alpha = (int)MathHelper.Lerp(0, 255, (20 - Projectile.timeLeft) / 20f);
                Projectile.velocity *= .9f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation();
            CheckFrame();
        }
        private void CheckFrame()
        {
            if (++Projectile.frameCounter >= 3f)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }
        public override void OnKill(int timeleft)
        {
            Projectile.Center.LookForHostileNPC(out List<NPC> npclist, 140);
            foreach (NPC npc in npclist)
            {
                Main.player[Projectile.owner].StrikeNPCDirect(npc, npc.CalculateHitInfo(Projectile.damage / 2, 0));
            }
            for (int b = 0; b < 80; b++)
            {
                Dust.NewDustPerfect(Projectile.Center, DustID.WhiteTorch, Main.rand.NextVector2CircularEdge(3f, 3f) * 5, Scale: 3f).noGravity = true;
                Dust.NewDustPerfect(Projectile.Center, DustID.PurpleTorch, Main.rand.NextVector2CircularEdge(3f, 3f) * 5, Scale: 3f).noGravity = true;
                Dust.NewDustPerfect(Projectile.Center, DustID.Bone, Main.rand.NextVector2CircularEdge(3f, 3f) * 5, Scale: 2f).noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
        }
    }
}