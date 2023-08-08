using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Tiles;
using TheSkeletronMod.Items.Materials;
using TheSkeletronMod;

namespace TheSkeletronMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class CartilageLeggings : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetAttackSpeed(ModContent.GetInstance<Bonecursed>()) += 0.02f;
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
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 15);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }
       
    }
}
