using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
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
            Item.ItemSetDefault(84, 75, 40, 2.5f, 22, 22, ItemUseStyleID.Thrust, true);
            Item.ItemSetDefaultSpear(ModContent.ProjectileType<RattleboneRapierProj>(), 22);
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
        protected virtual float HoldoutRangeMin => 24f;
        protected virtual float HoldoutRangeMax => 96f;
        public override void SetDefaults()
        {
            Projectile.width = 84;
            Projectile.height = 76;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.scale = 1f;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            int projlong = player.itemAnimationMax;

            player.heldProj = Projectile.whoAmI;
            if (Projectile.timeLeft > projlong)
            {
                Projectile.timeLeft = projlong;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

            float halfprojlong = projlong * 0.5f;
            float progress;

            // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
            if (Projectile.timeLeft < halfprojlong)
            {
                progress = Projectile.timeLeft / halfprojlong;
            }
            else
            {
                progress = (projlong - Projectile.timeLeft) / halfprojlong;
            }
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);
            if (Projectile.spriteDirection == -1)
            {

                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                Projectile.rotation += MathHelper.ToRadians(135f);
            }
            return false;
        }
    }
}
