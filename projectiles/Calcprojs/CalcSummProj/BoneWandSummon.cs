using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Buffs;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcSummProj
{
    class BoneWandSummon : ModProjectile
    {
        private Vector2 velocity = new Vector2(0, 0);
        private float maxVel = 8f;
        public override void SetDefaults()
        {
            Projectile.minion = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.minionSlots = 1f;
            Projectile.damage = 25;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 10;
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
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<BoneWandBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<BoneWandBuff>()))
            {
                Projectile.timeLeft = 2;
                player.AddBuff(ModContent.BuffType<BoneWandBuff>(),2);
            }
            NPC target = Projectile.FindTargetWithinRange(700f);
            Vector2 targetPos = new(0, 0);
            if (target == null || target.type == 0)
            {
                targetPos = player.position;
            }
            else if (!target.CanBeChasedBy(Projectile.type)){
                targetPos = player.position;
            }
            else
            {
                targetPos = target.position;
            }
            Vector2 moveV = targetPos - Projectile.position;
            moveV.Normalize();
            velocity += moveV;
            if (velocity.Length() > maxVel)
            {
                velocity.Normalize();
                velocity *= maxVel;
            }
            Projectile.position += velocity;
        }
    }
}
