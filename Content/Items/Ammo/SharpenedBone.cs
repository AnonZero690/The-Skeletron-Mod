using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcRangeProj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Ammo
{
    internal class SharpenedBone : ModItem
    {
        public override void SetStaticDefaults() {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            Item.damage = 6;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.knockBack = 1f;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.ammo = AmmoID.Stake;
            Item.shoot = ModContent.ProjectileType<SharpenedBoneProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.ReplaceResult(this,5);
            recipe.Register();
        }
    }
}
