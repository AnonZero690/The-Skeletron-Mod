using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcRange
{
    internal class BoneBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }
        public override void SetDefaults()
        {
            Item.ItemSetDefault(30, 36, 34, 5f, 40, 40, ItemUseStyleID.Swing, true);
            Item.DefaultToRangedWeapon(ModContent.ProjectileType<BoneBombProjectile>(), AmmoID.None, 40, 7, true);
            Item.DamageType = DamageClass.Ranged;
            Item.noUseGraphic = true;
            Item.consumable = true;
            Item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 2);
            recipe.AddIngredient(ModContent.GetInstance<AncientBone>(), 5);
            recipe.AddIngredient(ItemID.Grenade, 5);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.ReplaceResult(this, 5);
            recipe.Register();
        }
        public class BoneBombProjectile : ModProjectile
        {
            public override string Texture => SkeletronUtils.GetEntityTexture<BoneBomb>();
            public override void SetDefaults()
            {
                Projectile.width = Projectile.height = 30;
                Projectile.friendly = true;
                Projectile.tileCollide = true;
                Projectile.timeLeft = 210;
                Projectile.penetrate = 1;
            }
            public override void AI()
            {
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Bone);
                if (Projectile.velocity != Vector2.Zero)
                {
                    Projectile.rotation += MathHelper.ToRadians(Projectile.velocity.Length() * 2.5f) * (Projectile.velocity.X > 0 ? 1 : -1);
                }
                Projectile.ai[0]++;
                if (Projectile.ai[0] <= 20)
                {
                    return;
                }
                if (Projectile.velocity.Y < 23)
                {
                    Projectile.velocity.Y += .4f;
                }
            }
            public override bool OnTileCollide(Vector2 oldVelocity)
            {
                if (Projectile.velocity.X != oldVelocity.X)
                    Projectile.velocity.X = -oldVelocity.X;
                Projectile.velocity.Y = -oldVelocity.Y * .8f;
                return false;
            }
            public override void OnKill(int timeLeft)
            {
                Player player = Main.player[Projectile.owner];
                List<NPC> npclist = Projectile.Center.GetNPCsInRange(200f);
                foreach (NPC npc in npclist)
                {
                    player.StrikeNPCDirect(npc, npc.CalculateHitInfo(Projectile.damage, 1));
                }
                for (int i = 0; i < 75; i++)
                {
                    int dust = Dust.NewDust(Projectile.Center, 0, 0, DustID.Smoke, Scale: Main.rand.NextFloat(3f, 4f));
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity = Main.rand.NextVector2Circular(15, 15);
                    int dust1 = Dust.NewDust(Projectile.Center, 0, 0, DustID.Torch, Scale: Main.rand.NextFloat(2f, 3f));
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity = Main.rand.NextVector2Circular(15, 15);
                }
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = Projectile.velocity.Vector2Evenly(10, 360, i);
                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, vel.LimitLength(5f), ProjectileID.Bone, (int)(Projectile.damage * .65f), Projectile.knockBack, Projectile.owner);
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].penetrate = -1;
                    Main.projectile[proj].maxPenetrate = -1;
                }
            }
        }
    }
}