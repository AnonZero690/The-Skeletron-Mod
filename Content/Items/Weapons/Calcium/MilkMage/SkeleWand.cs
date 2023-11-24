using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.MilkMage
{

    public class SkeleWand : ModItem
    {
        public int MIN = -20;
        public int MAX = -20;

        public override void SetStaticDefaults()
        {

            //          Tooltip.SetDefault("Conjures bouncing crossbones"
            //   + "\nThese crossbones bounce for a while then eventually snap");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;

            Item.autoReuse = true;
            Item.staff[Item.type] = true;

            Item.useTurn = true;
            Item.mana = 5;
            Item.damage = 20;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.knockBack = 1f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.shootSpeed = 9f;

            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.DD2_SkeletonSummoned;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 8000;

            Item.shoot = ProjectileID.BoneGloveProj;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {



            float numberProjectiles = 1 + Main.rand.Next(1); // 3, 4, or 5 shotsx`
            float rotation = MathHelper.ToRadians(3);
            position += Vector2.Normalize(velocity) * 3;
            for (int i = 1; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.BoneGloveProj, damage, knockback, player.whoAmI);
            }

            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)(player.position.X + player.width * 0.5 +
                             Main.rand.Next(201) * -player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X)),
                    (float)(player.position.Y + player.height * 0.5 -
                             600.0));
                vector2_1.X = (float)((vector2_1.X + player.Center.X) / 2.0) +
                              Main.rand.Next(-200, 201);
                vector2_1.Y -= 100 * index;
                float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if (num13 < 0.0) num13 *= -1f;
                if (num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
                float num15 = Item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + Main.rand.Next(MIN, MAX) * 0.02f; //Projectile Spread
                float SpeedY = num17 + Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(Terraria.Entity.GetSource_None(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage,
                                 knockback, Main.myPlayer, 0.0f, Main.rand.Next(1));
            }

            return false;
        }
        public override bool OnPickup(Player player)
        {
            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            var offset = new Vector2(1, 0);
            return offset;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 20);
            recipe.AddIngredient(ItemID.WandofSparking, 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
    }
}