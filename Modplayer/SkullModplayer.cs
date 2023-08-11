
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Accessories;

namespace TheSkeletronMod.Modplayer
{
    public class SkullModplayer : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {

            return (IEnumerable<Item>)(object)new Item[1]
            {
                new Item(ModContent.ItemType<SkullPendant>(), 1, 0),
            };
        }
    }
}
