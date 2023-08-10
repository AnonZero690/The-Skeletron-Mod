using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Weapons.Calcium
{
    public class CartilageSpear : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<CartilageSpearProjectile>();
            Item.value = 16000;
            Item.crit = 5;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.damage = 4;
            Item.width = 58;
            Item.height = 58;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 11f;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 36);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }
        public override void PostUpdate()
        {

            Item.damage = 20;

            if (Item.timeSinceItemSpawned % 12 == 0)
            {
                Vector2 center = Item.Center + new Vector2(0f, Item.height * -0.1f);

                Vector2 direction = Main.rand.NextVector2CircularEdge(Item.width * 0.6f, Item.height * 0.6f);
                float distance = 0.3f + Main.rand.NextFloat() * 0.5f;
                var velocity = new Vector2(0f, -Main.rand.NextFloat() * 0.3f - 1.5f);

                var dust = Dust.NewDustPerfect(center + direction * distance, DustID.Bone, velocity);
                dust.scale = 0.5f;
                dust.fadeIn = 0.4f;
                dust.noGravity = true;
                dust.noLight = false;
                dust.alpha = 0;
            }
        }

    }
}
