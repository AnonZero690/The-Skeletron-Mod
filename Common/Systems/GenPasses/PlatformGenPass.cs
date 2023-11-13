using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria;
using Terraria.WorldBuilding;
using TheSkeletronMod.Tiles.Blocks;

namespace TheSkeletronMod.Common.Systems.GenPasses
{
    internal class PlatformGenPass : GenPass
    {
        public PlatformGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating spawn platform";

            int x = Main.maxTilesX / 2;
            int y = Main.maxTilesY - 200;
            int size = 200;
            for (int i = -size; i < size; i++)
            {
                WorldGen.PlaceTile(x + i, y, TileID.RainbowBrick);
            }
        }
    }
}
