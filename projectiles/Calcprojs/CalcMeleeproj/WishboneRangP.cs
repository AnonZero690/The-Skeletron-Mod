using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class WishboneRangP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.tileCollide = false;
            Projectile.timeLeft = 999;
            Projectile.penetrate = -1;
        }
        float MaxLengthX = 0;
        float MaxLengthY = 0;

        int MouseXPosDirection;
        int maxProgress = 65;
        int progression = 0;
        Player player;
        public override void AI()
        {
            //we are setting basic field value here
            if (Projectile.timeLeft == 999)
            {
                player = Main.player[Projectile.owner];
                //This is artifact code, it always true
                if (Projectile.ai[0] == 0)
                    Projectile.ai[0] = Main.rand.NextBool().BoolOne();
                //we set how far can the boomerang can goes on horizontal line
                MaxLengthX = (Main.MouseWorld - player.Center).Length();
                //here the max progression get add base on how far it need to travel
                maxProgress += (int)(MaxLengthX * .05f);
                progression = maxProgress;
                //the name self explain
                MouseXPosDirection = (int)Projectile.ai[0] * (Main.MouseWorld.X - player.Center.X > 0 ? 1 : -1);
                //we set how far can the boomerang can goes on vertical line
                MaxLengthY = -(MaxLengthX + Main.rand.NextFloat(-10, 80)) * .25f * MouseXPosDirection;
            }

            if (player.dead || !player.active || progression <= 0)
            {
                Projectile.Kill();
            }
            //we set half max progress here
            int halfmaxProgress = (int)(maxProgress * .5f);
            //we set quad max progress here
            int quadmaxProgress = (int)(maxProgress * .25f);
            float progress;
            //here we keep track of progress on horizontal axis
            // since progression here goes from max to 0
            // we are checking if it larger than half, and if it do then the lerp percentage goes from 0 -> 1
            // otherwise it goes from 1 -> 0
            if (progression > halfmaxProgress)
            {
                progress = (maxProgress - progression) / (float)halfmaxProgress;
            }
            else
            {
                progress = progression / (float)halfmaxProgress;
            }
            //we set X position here
            float X = MathHelper.SmoothStep(-10, MaxLengthX, progress);
            //the same idea above but more complicated
            ProgressYHandle(progression, halfmaxProgress, quadmaxProgress, out float Y);
            //here we rotate the path of the boomerang depending on the rotation of the Projectile.velocity
            Vector2 VelocityPosition = new Vector2(X, Y).RotatedBy(Projectile.velocity.ToRotation());
            //here the actual movement
            Projectile.Center = player.Center + VelocityPosition;
            progression--;
            //Rotating the boomerang
            Projectile.rotation += MathHelper.ToRadians(55);
        }
        private void ProgressYHandle(int timeleft, float progressMaxHalf, float progressMaxQuad, out float Y)
        {
            //have fun figuring this out yourself
            if (timeleft > progressMaxHalf + progressMaxQuad)
            {
                float progressY = 1 - (timeleft - (progressMaxHalf + progressMaxQuad)) / progressMaxQuad;
                Y = MathHelper.SmoothStep(0, MaxLengthY, progressY);
                return;
            }
            if (timeleft > progressMaxQuad)
            {
                float progressY = 1 - (timeleft - progressMaxQuad) / progressMaxHalf;
                Y = MathHelper.SmoothStep(MaxLengthY, -MaxLengthY, progressY);
                return;
            }
            else
            {
                float progressY = 1 - timeleft / progressMaxQuad;
                Y = MathHelper.SmoothStep(-MaxLengthY, 0, progressY);
                return;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Projectile.velocity.X * -2, Projectile.velocity.Y), ModContent.ProjectileType<WishboneRangPOne>(), 7, 2, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Projectile.velocity.X * -1.6f, Projectile.velocity.Y), ModContent.ProjectileType<WishboneRangPTwo>(), 9, 2, Projectile.owner);
        }
    }
    public class WishboneRangPOne : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
            Projectile.penetrate = 2;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.aiStyle = 1;
        }
        //public override void AI()
        //{
        //    Projectile.velocity.Y = Projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
        //    if (Projectile.velocity.Y > 16f) // terminal velocity
        //    {
        //        Projectile.velocity.Y = 16f;
        //    }
        //}
    }
    public class WishboneRangPTwo : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
            Projectile.penetrate = 3;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.aiStyle = 1;
        }
        //public override void AI()
        //{
        //    Projectile.velocity.Y = Projectile.velocity.Y + 0.3f; // 0.1f for arrow gravity, 0.4f for knife gravity
        //    if (Projectile.velocity.Y > 16f) // terminal velocity
        //    {
        //        Projectile.velocity.Y = 16f;
        //    }
        //}
    }
}
