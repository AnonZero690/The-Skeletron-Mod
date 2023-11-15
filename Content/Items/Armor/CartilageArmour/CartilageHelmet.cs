using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Buffs;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CartArmour;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Armor.CartilageArmour
{
    [AutoloadEquip(EquipType.Head)]
    public class CartilageHelmet : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.02f;
        }
        public override void SetDefaults()
        {
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 10);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CartilageChestplate>() && legs.type == ModContent.ItemType<CartilageLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage<Bonecursed>() += 0.1f;
            player.AddBuff(ModContent.BuffType<DeadlySkull>(), 1);
            player.setBonus = "10% increased calcium damage\nSummons a skull that conjures cursed beams towards enemies";
            if (player.ownedProjectileCounts[ModContent.ProjectileType<CartilageSkull>()] < 1)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), new Vector2(player.position.X, player.position.Y - 75), new Vector2(0, 0), ModContent.ProjectileType<CartilageSkull>(), 0, 0, player.whoAmI);
            }
        }
    }
}
