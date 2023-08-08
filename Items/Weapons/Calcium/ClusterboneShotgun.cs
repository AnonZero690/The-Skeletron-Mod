using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Systems;
using TheSkeletronMod.projectiles;
using static Terraria.ModLoader.ModContent;


namespace TheSkeletronMod.Items.Weapons.Ranged
{

    public class ClusterboneShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = 30000;
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.noMelee = true;
            Item.shootSpeed = 60f;
            Item.shoot = ProjectileID.Bullet;
            Item.UseSound = SkelSound.BoneCrunchShot;


            /// <summary>
            /// From now on----- Item.UseSound = SoundID.WHATEVER is NOW
            /// -> Item.UseSound = SkelSound.FieldName;
            /// </summary>


        }



        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
        

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

          
            Lighting.AddLight(player.position, r: 0.8f, 0.5f, 0.0f);
            const int NumProjectiles = 3;

            for (int i = 0; i < NumProjectiles; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(13));
                newVelocity *= 1f - Main.rand.NextFloat(0.2f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            player.GetModPlayer<Screenshake>().SmallScreenshake = true;

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                position += muzzleOffset;

            if (Main.rand.NextBool(10))
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<BigSkull>(), damage, knockback, player.whoAmI);

            }
            Gore.NewGore(source, player.Center + muzzleOffset * 1, new Vector2(player.direction * -1, -0.5f) * 2, Mod.Find<ModGore>("GunPellets").Type, 1f);

            Projectile.NewProjectile(player.GetSource_ItemUse(Item), position + muzzleOffset, Vector2.Zero, ProjectileType<GunBarrelFlash>(), 0, 0, player.whoAmI);
          




            /*          Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                      float ceilingLimit = target.Y;
                      if (ceilingLimit > player.Center.Y - 200f)
                          ceilingLimit = player.Center.Y - 200f;
                      // Loop these functions 3 times.
                      for (int i = 0; i < 3; i++)
                      {
                          position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                          position.Y -= 100 * i;
                          Vector2 heading = target - position;

                          if (heading.Y < 0f)
                              heading.Y *= -1f;

                          if (heading.Y < 20f)
                              heading.Y = 20f;

                          heading.Normalize();
                          heading *= velocity.Length();
                          heading.Y += Main.rand.Next(1, 3) * 0.02f;
                          Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<Snowy>(), damage * 1, knockback, player.whoAmI, 0f, ceilingLimit);
            */
            return true;
        }

   /*     public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
   */
        public override Vector2? HoldoutOffset()
        {
            var offset = new Vector2(-2, 0);
            return offset;
        }
    }
}







