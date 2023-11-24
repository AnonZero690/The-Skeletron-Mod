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

namespace TheSkeletronMod.Common.Systems.GenPasses
{
    internal class PlatformGenPass : GenPass
    {
        public PlatformGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating spawn platform";
            
            int y = (int)Main.worldSurface;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                WorldGen.PlaceTile(i, y, TileID.RainbowBrick);
            }
        }
    }
}
