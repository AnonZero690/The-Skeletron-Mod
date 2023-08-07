using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Placeables
{
	internal class BoneAltar : ModItem
	{
		public override void SetStaticDefaults()
		{
			//CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;

			Item.useTime = 15;
			Item.useAnimation = 15;

			Item.useStyle = ItemUseStyleID.Swing;

			Item.autoReuse = true;
			Item.useTurn = true;

			Item.maxStack = 999;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<BoneAltarTile>();
			Item.placeStyle = 0;
		}
	}
}