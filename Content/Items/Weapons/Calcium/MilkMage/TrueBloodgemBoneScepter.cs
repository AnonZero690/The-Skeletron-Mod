using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.MilkMage
{
    public class TrueBloodgemBoneScepter : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeCustomProjectile(22, 38, 70, 2f, 17, 17, ItemUseStyleID.Shoot, ModContent.ProjectileType<ClonedBloodArrow>(), true);
            Item.value = 10000;
            Item.crit = 5;
            Item.shootSpeed = 7;
            Item.noUseGraphic = false;
            Item.noMelee = true;
            Item.UseSound = SoundID.DD2_BetsySummon;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 1;
            Item.mana = 10;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BloodgemBoneScepter>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -1);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 newPos = new Vector2(position.X - 3, position.Y + 4);
            base.ModifyShootStats(player, ref newPos, ref velocity, ref type, ref damage, ref knockback);
            position = position.PositionOFFSET(velocity, 50);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int randomNumber = 2;
            for (int y = 0; y < Main.rand.Next(1,26);y++)
            {
                int otherRandom = Main.rand.Next(0, 2);
                randomNumber += otherRandom;
                if (otherRandom == 0)
                {
                    y = 100;
                }
            }
            
            for (int i = 0; i < randomNumber; i++)
            {
                Vector2 vec = velocity.Vector2Evenly(randomNumber + 1, 50, i);
                Projectile.NewProjectile(source, position, vec, ModContent.ProjectileType<ClonedBloodArrow>(), (int)(damage / (randomNumber * 0.8 / 2)), knockback, player.whoAmI, 0, 1);
            }


            return true;
        }
    }
}
