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
using TheSkeletronMod.Content.Tiles.Blocks;

namespace TheSkeletronMod.Common.Systems.GenPasses
{
    internal class OreGenPass : GenPass
    {
        public OreGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Ores";

            // Calcium Ore
            var maxToSpawn = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);
            for (var i = 0; i < maxToSpawn; i++)
            {
                var x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                var y = WorldGen.genRand.Next((int)GenVars.worldSurface, Main.maxTilesY - 300);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 5), ModContent.TileType<CalciumOreT>());
            }
        }
    }
}
