using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TheSkeletronMod.Items.Tools
{
    public class GuardiansPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.pick = 100;
            Item.useAnimation = 15;
            Item.useTime = 15;
        }
    }
}
