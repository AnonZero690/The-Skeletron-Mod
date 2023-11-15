using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    //both item and proj code is here.
    public class RattleboneRapier : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.ItemSetDefault(84, 75, 40, 2.5f, 15, 15, ItemUseStyleID.Shoot, true);
            Item.DefaultToSpear(ModContent.ProjectileType<RattleboneRapierProj>(), 22, 15);
            // Item.ItemSetDefaultSpear(ModContent.ProjectileType<RattleboneRapierProj>(), 22);
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }

    }
    public class RattleboneRapierProj : ModProjectile
    {
        //who knew this'd be annoying to make ♥
        protected virtual float HoldoutRangeMin => 74f;
        protected virtual float HoldoutRangeMax => 96f;
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 30;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 19;

            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;
            player.heldProj = Projectile.whoAmI;
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
                Projectile.velocity = Vector2.Normalize(Projectile.velocity).Vector2RotateByRandom(10);
            }
            float halfDuration = duration * 0.5f;
            float progress;

            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);
            Projectile.rotation += Projectile.spriteDirection == -1 ? MathHelper.PiOver4 : MathHelper.PiOver4 + MathHelper.PiOver2;
            return false;
        }
    }
}
