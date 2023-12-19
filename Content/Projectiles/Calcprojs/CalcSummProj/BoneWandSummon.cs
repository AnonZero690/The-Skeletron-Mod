using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Buffs;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcSummProj
{
    class BoneWandSummon : ModProjectile
    {
        private Vector2 targetPos = new(0, 0);
        private Vector2 velocity = new Vector2(0, 0);
        private bool idle = true;
        private float maxVel = 32f;
        public override void SetDefaults()
        {
            Projectile.minion = true;
            Projectile.width = 56;
            Projectile.height = 76;
            Projectile.minionSlots = 1f;
            Projectile.damage = 25;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 10;
            Projectile.tileCollide = false;
        }
        public override void SetStaticDefaults()
        {
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            targetPos = player.position;
            idle = true;
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<BoneWandBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<BoneWandBuff>()))
            {
                Projectile.timeLeft = 2;
                player.AddBuff(ModContent.BuffType<BoneWandBuff>(),2);
            }
            NPC target = Projectile.FindTargetWithinRange(400f-(Projectile.position-player.position).Length());

            if(!(target==null))
            {
                if ((target.type != NPCID.None) && target.CanBeChasedBy())
                {
                    targetPos = target.position;
                    idle = false;
                }
            }
            if (!idle) 
            {
                Vector2 moveV = targetPos - Projectile.position;
                Vector2 StillCheck = moveV;
                moveV.Normalize();
                if (0 > (moveV.Length() - StillCheck.Length()))
                {
                    velocity += moveV*4f;
                }
                if (velocity.Length() > maxVel)
                {
                    velocity.Normalize();
                    velocity *= maxVel;
                }
            } else
            {
                targetPos = player.position;
                double miniondiv = player.ownedProjectileCounts[ModContent.ProjectileType<BoneWandSummon>()]/(Projectile.minionPos+1);
                miniondiv = miniondiv*Math.PI;
                targetPos += new Vector2((float)Math.Cos(miniondiv)*64f, (float)Math.Sin(miniondiv)*64f);

            }
            
            Projectile.position += velocity;
        }
    }
}
