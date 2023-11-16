using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    internal class BoneYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 7;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.5f;
            Item.damage = 16;
            Item.rare = 6;

            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.buyPrice(gold: 50);
            Item.shoot = ModContent.ProjectileType<BoneYoyoProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0, 0, 1);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DaoofPow)
                .AddIngredient(ItemID.Chik)
                .Register();
        }
    }
    public class BoneYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 25f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 200f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 11;
        }
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 16;
            Projectile.height = 16;
        }
        public override void PostAI()
        {
            if (Projectile.ai[2] != 1)
                return;
            if (Main.rand.NextBool(25))
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, Main.rand.NextVector2Circular(7f, 7f), ProjectileID.BoneGloveProj, (int)(Projectile.damage * .65f), Projectile.knockBack, Projectile.owner);

        }
    }
}
