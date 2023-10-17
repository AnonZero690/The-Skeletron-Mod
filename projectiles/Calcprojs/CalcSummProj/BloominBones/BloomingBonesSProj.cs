using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcSummProj.BloominBones
{
    public class BloomingBonesSProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 13;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;


            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }

        public sealed override void SetDefaults()
        {
            Projectile.width = 94;
            Projectile.height = 100;
            Projectile.tileCollide = false;

            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 3;
            Projectile.penetrate = -1;
        }

        public override bool? CanCutTiles() => false;

        public override bool MinionContactDamage() => false;

        /*public override void AI()
        {
            float detectionRadius = 750f;
            Vector2 targetCenter = Projectile.position;
            Vector2 targetPosition = Projectile.position;
            Vector2 targetVelocity = Projectile.velocity;
            Player player = Main.player[Projectile.owner];

            bool foundTarget = false;
            float between = Vector2.Distance(targetCenter, Projectile.Center);
            Vector2 targetSize = Vector2.Zero;


            bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
            bool inRange = between < detectionRadius;
            bool inRangePlayer = Projectile.Distance(player.Center) > 2000;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                bool DashHit = dashHit.Contains(npc);
                if (between < 2000f && !DashHit)
                {
                    detectionRadius = between;
                    targetCenter = npc.Center;
                    targetPosition = npc.position;
                    targetVelocity = npc.velocity;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    bool DashHit = dashHit.Contains(npc);
                    if (npc.CanBeChasedBy())
                    {
                        if (inRange && inRangePlayer && !DashHit || !foundTarget)
                        {
                            List<Vector2> Positions = new List<Vector2>();
                            Positions.Add(npc.Center);
                            if (npc.Center == Pathfinding.GetNearestPos(player.Center, Positions))
                            {
                                detectionRadius = between;
                                targetCenter = npc.Center;
                                targetPosition = npc.position;
                                targetVelocity = npc.velocity;
                                foundTarget = true;
                            }
                        }
                    }
                }
            }
        }
        */
    }
}
