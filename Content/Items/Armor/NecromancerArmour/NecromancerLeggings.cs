using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Armor.NecromancerArmour
{
    [AutoloadEquip(EquipType.Legs)]
    public class NecromancerLeggings : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.GetCritChance(ModContent.GetInstance<Bonecursed>()) += 0.08f;
        }
        public override void SetDefaults()
        {
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 8;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 5);   
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

    }
}
