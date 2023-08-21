using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.projectiles;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Placeables
{
    public class BoneToiletItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.useAnimation = 15;
            Item.useTime = 15;

            Item.height = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 27;
            Item.useTime = 27;
            Item.UseSound = SoundID.DD2_GoblinBomberThrow;
            Item.autoReuse = true;
                
            Item.damage = 18;
            Item.knockBack = 2f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;

            Item.shootSpeed = 10f;
            Item.shoot = ProjectileID.None;

            Item.value = 150;
            Item.createTile = ModContent.TileType<BoneToilet>();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));

            if (Main.rand.NextBool(5))
                type = ModContent.ProjectileType<BoneToiletThrow>();

        }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Materials.AncientBone>(),4 )
                .AddIngredient(ItemID.Bone, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}