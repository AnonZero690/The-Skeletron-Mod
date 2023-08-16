using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using TheSkeletronMod.Tiles;
using System.Collections.Generic;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    internal class WhittledBone : ModItem, MeleeWeaponWithImprovedSwing
    {
        public float swingDegree => 150;
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(54, 66, 50, 7f, 25, 25, ItemUseStyleID.Swing, ModContent.ProjectileType<WhittledBoneP>(), 0, true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.damage = 10;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 10, 10);
            Item.width = 46;
            Item.height = 78;
            Item.autoReuse = false;

        }
        
        
        

       

        public override void AddRecipes()
        {
            CreateRecipe()
                
                .AddIngredient(ItemID.Bone, 15)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
    
    public class WhittledBoneP : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<WhittledBone>();
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.DontAttachHideToAlpha[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 78;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 100;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.hide = Projectile.ai[1] != 2;
            DrawOffsetX = -10;
        }


        public override void AI()
        {
            Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
            Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Center, DustID.Bone, speed * 10, Scale: 1f); ;
            d.noGravity = true;
        }


    }
}