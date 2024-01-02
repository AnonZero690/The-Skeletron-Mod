using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    public class WishboneRang : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;         // Damage the boomerang does
            Item.knockBack = 4;       // Knockback value
            Item.useStyle = ItemUseStyleID.Swing; // Style of use (swinging or throwing)
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.useAnimation = 20;   // Animation duration (in frames)
            Item.useTime = 20;        // Time between throws (in frames)
            Item.width = 24;           // Width of the boomerang hitbox
            Item.height = 24;          // Height of the boomerang hitbox
            Item.scale = 1.25f;        //how big the sprite is
            Item.noMelee = true;       // It doesn't deal melee damage
            Item.value = Item.sellPrice(silver: 5); // Sell value in silver coins
            Item.rare = ItemRarityID.Green; // Rarity (choose one)
            Item.UseSound = SoundID.Item1; // Sound effect when used
            Item.shoot = ModContent.ProjectileType<WishboneRangP>(); // The projectile it throws
            Item.shootSpeed = 10f; // The speed at which it is thrown
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PlatinumBone>(), 5);
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
