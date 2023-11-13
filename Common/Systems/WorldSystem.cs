using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using TheSkeletronMod.Common.Systems.GenPasses;

namespace TheSkeletronMod.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            if(Main.worldName.Contains("Vanilla"))
            {
                return;
            }
            RemoveNormalTasks(tasks);
            //int PassID = tasks.Count();
            //tasks.Insert

            














            //int shiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
            //if (shiniesIndex != -1)
            //{
            //    tasks.Insert(shiniesIndex + 1, new OreGenPass("Ore Pass", 320f));
            //}
        }

        private void RemoveNormalTasks(List<GenPass> tasks)
        {
            #region Dont expand this
            RemoveTask(tasks, "Reset");
            RemoveTask(tasks, "Terrain");
            RemoveTask(tasks, "Dunes");
            RemoveTask(tasks, "Ocean Sand");
            RemoveTask(tasks, "Sand Patches");
            RemoveTask(tasks, "Tunnels");
            RemoveTask(tasks, "Mount Caves");
            RemoveTask(tasks, "Dirt Wall Backgrounds");
            RemoveTask(tasks, "Rocks In Dirt");
            RemoveTask(tasks, "Dirt In Rocks");
            RemoveTask(tasks, "Clay");
            RemoveTask(tasks, "Small Holes");
            RemoveTask(tasks, "Dirt Layer Caves");
            RemoveTask(tasks, "Rock Layer Caves");
            RemoveTask(tasks, "Surface Caves");
            RemoveTask(tasks, "Wavy Caves");
            RemoveTask(tasks, "Grass");
            RemoveTask(tasks, "Jungle");
            RemoveTask(tasks, "Mud Caves To Grass");
            RemoveTask(tasks, "Full Desert");
            RemoveTask(tasks, "Floating Islands");
            RemoveTask(tasks, "Mushroom Patches");
            RemoveTask(tasks, "Marble");
            RemoveTask(tasks, "Granite");
            RemoveTask(tasks, "Dirt To Mud");
            RemoveTask(tasks, "Silt");
            RemoveTask(tasks, "Shinies");
            RemoveTask(tasks, "Webs");
            RemoveTask(tasks, "Underworld");
            RemoveTask(tasks, "Corruption");
            RemoveTask(tasks, "Lakes");
            RemoveTask(tasks, "Dungeon");
            RemoveTask(tasks, "Slush");
            RemoveTask(tasks, "Mountain Caves");
            RemoveTask(tasks, "Beaches");
            RemoveTask(tasks, "Gems");
            RemoveTask(tasks, "Gravitating Sand");
            RemoveTask(tasks, "Create Ocean Caves");
            RemoveTask(tasks, "Shimmer");
            RemoveTask(tasks, "Clean Up Dirt");
            RemoveTask(tasks, "Pyramids");
            RemoveTask(tasks, "Dirt Rock Wall Runner");
            RemoveTask(tasks, "Living Trees");
            RemoveTask(tasks, "Wood Tree Walls");
            RemoveTask(tasks, "Wet Jungle");
            RemoveTask(tasks, "Altars");
            RemoveTask(tasks, "Jungle Temple");
            RemoveTask(tasks, "Hives");
            RemoveTask(tasks, "Jungle Chests");
            RemoveTask(tasks, "Settle Liquids");
            RemoveTask(tasks, "Remove Water From Sand");
            RemoveTask(tasks, "Oasis");
            RemoveTask(tasks, "Shell Piles");
            RemoveTask(tasks, "Smooth World");
            RemoveTask(tasks, "Waterfalls");
            RemoveTask(tasks, "Wall Variety");
            RemoveTask(tasks, "Life Crystals");
            RemoveTask(tasks, "Statues");
            RemoveTask(tasks, "Buried Chests");
            RemoveTask(tasks, "Surface Chests");
            RemoveTask(tasks, "Jungle Chests Placement");
            RemoveTask(tasks, "Water Chests");
            RemoveTask(tasks, "Spider Caves");
            RemoveTask(tasks, "Gem Caves");
            RemoveTask(tasks, "Moss");
            RemoveTask(tasks, "Temple");
            RemoveTask(tasks, "Cave Walls");
            RemoveTask(tasks, "Jungle Trees");
            RemoveTask(tasks, "Floating Island Houses");
            RemoveTask(tasks, "Quick Cleanup");
            RemoveTask(tasks, "Pots");
            RemoveTask(tasks, "Hellforge");
            RemoveTask(tasks, "Spreading Grass");
            RemoveTask(tasks, "Surface Ore and Stone");
            RemoveTask(tasks, "Place Fallen Log");
            RemoveTask(tasks, "Traps");
            RemoveTask(tasks, "Piles");
            RemoveTask(tasks, "Spawn Point");
            RemoveTask(tasks, "Grass Wall");
            RemoveTask(tasks, "Guide");
            RemoveTask(tasks, "Sunflowers");
            RemoveTask(tasks, "Planting Trees");
            RemoveTask(tasks, "Herbs");
            RemoveTask(tasks, "Dye Plants");
            RemoveTask(tasks, "Webs And Honey");
            RemoveTask(tasks, "Weeds");
            RemoveTask(tasks, "Glowing Mushrooms and Jungle Plants");
            RemoveTask(tasks, "Jungle Plants");
            RemoveTask(tasks, "Vines");
            RemoveTask(tasks, "Flowers");
            RemoveTask(tasks, "Mushrooms");
            RemoveTask(tasks, "Gems In Ice Biome");
            RemoveTask(tasks, "Generate Ice Biome");
            RemoveTask(tasks, "Random Gems");
            RemoveTask(tasks, "Moss Grass");
            RemoveTask(tasks, "Muds Walls In Jungle");
            RemoveTask(tasks, "Larva");
            RemoveTask(tasks, "Settle Liquids Again");
            RemoveTask(tasks, "Cactus, Palm Trees, &Coral");
            RemoveTask(tasks, "Tile Cleanup");
            RemoveTask(tasks, "Lihzahrd Altars");
            RemoveTask(tasks, "Micro Biomes");
            RemoveTask(tasks, "Water Plants");
            RemoveTask(tasks, "Stalac");
            RemoveTask(tasks, "Remove Broken Traps");
            RemoveTask(tasks, "Final Cleanup");
            #endregion
        }

        private void RemoveTask(List<GenPass> tasks, string name)
        {
            try
            {
                tasks.RemoveAt(tasks.FindIndex(t => t.Name.Equals(name)));
            }
            catch
            {
                ModContent.GetInstance<TheSkeletronMod>().Logger.Debug(name + " did not get removed, probably because it did not exist.");
            }
        }
    }
}
