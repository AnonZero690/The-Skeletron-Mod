using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Audio;
using System.Collections.Generic;
using TheSkeletronMod.Buffs;
using TheSkeletronMod.Items.Weapons.Calcium.CalcMelee;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneDaggerProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<BoneDagger>();

        bool stick = false;
        int targetBone;
        float rotation;

        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = Projectile.height = 24;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (stick)
            {

                Projectile.rotation = rotation;
                int npcTarget = targetBone;
                Projectile.Center = Main.npc[npcTarget].Center - Projectile.velocity;
                Projectile.gfxOffY = Main.npc[npcTarget].gfxOffY;
                Main.npc[npcTarget].HitEffect(0, 1.0);
            }
        }

        public override void Kill(int timeleft)
        {
            for (int i = 0; i < 17; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 50, default, 1f);

            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (stick == false)
            {
                stick = true;
                rotation = Projectile.rotation;
                targetBone = target.whoAmI;
                target.AddBuff(ModContent.BuffType<BoneDaggerr>(), Projectile.timeLeft);
                Projectile.damage = 0;
                Projectile.velocity = (target.Center - Projectile.Center) * 0.75f;
                Projectile.netUpdate = true;
                Projectile.tileCollide = false;
                if (!Main.npc[targetBone].active)
                {
                    Projectile.Kill();
                }
            }
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            if (stick)
            {
                int npcIndex = targetBone;
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                    {
                        behindNPCsAndTiles.Add(index);
                    }
                    else
                    {
                        behindNPCsAndTiles.Add(index);
                    }

                    return;
                }
            }
            behindNPCsAndTiles.Add(index);
        }


    }
}