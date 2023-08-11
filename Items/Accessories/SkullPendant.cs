using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TheSkeletronMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class SkullPendant : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 20;
            Item.value = 12000;
            Item.rare = 2;
            Item.material = true;
            Item.accessory = true;
        }
        bool alreadySpawned = false;

        public override void AddRecipes()
        {
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        bool alreadySpawned = false;
        // Not supposed to be craftable
        //public override void AddRecipes()

    }
}