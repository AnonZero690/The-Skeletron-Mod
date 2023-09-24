
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Accessories.PendantTree;

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

        public int cc;

        public const int ccMMM = 100;

        public int ccM;

        public int ccMM;

        internal int ccT = 0;

        public bool ShowChargeBar = false;

        public Projectile proj;

        public NPC npc;

        public override void PostUpdateMiscEffects()
        {
            cc = Utils.Clamp(cc, 0, ccMM);
        }

        public override void Initialize()
        {
            ccM = ccMMM;
        }

        public override void ResetEffects()
        {
            ccMM = ccM;
        }

        public override void PostUpdate()
        {
            
        }
    }
}
