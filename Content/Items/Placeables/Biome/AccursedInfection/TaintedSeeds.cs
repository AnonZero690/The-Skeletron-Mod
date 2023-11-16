using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Tiles.Blocks.Biomes.AccursedInfection;

namespace TheSkeletronMod.Content.Items.Placeables.Biome.AccursedInfection
{
    internal class TaintedSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.value = Item.buyPrice(silver: 20);
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        { //I want to thank Lion8Cake for this. Bro really helps.
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);

            if ((tile.HasTile && tile.TileType == ModContent.TileType<Tiles.Blocks.Biomes.AccursedInfection.TaintedSoilT>() || tile.HasTile && tile.TileType == TileID.Dirt) &&
            player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
            {
                SoundEngine.PlaySound(SoundID.Dig, player.Center);

                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<TaintedGrassT>();

                return true;
            }

            return false;
        }
    }
}
