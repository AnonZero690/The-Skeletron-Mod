using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Accessories.PendantTree;

namespace TheSkeletronMod.Modplayer
{
    public class SkullModplayer : ModPlayer
    {

        // SUBJECT TO CHANGE //

        public override void OnEnterWorld()
        {
            Main.NewText("Welcome to the [c/FF0000:B][c/DF0020:o][c/BF0040:n][c/9F0060:e][c/800080:s][c/60009F: O][c/40009F:f][c/2000DF: D][c/0000FF:e][c/FF0000:s][c/DF0020:o][c/BF0040:l][c/9F0060:a][c/800080:t][c/60009F:i][c/40009F:o][c/2000DF:n][c/0000FF:!] - We hope you enjoy :D");
            base.OnEnterWorld();
        }
        public override void OnRespawn()
        {
            Main.NewText("Your bones magically pull them selves together and... Here you are again!");
            base.OnRespawn();
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Main.NewText("[c/E11919:Your bones ricochet and settle on the ground... ]");
            base.Kill(damage, hitDirection, pvp, damageSource);
        }

        // ------------------ //
     






        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {

            return (IEnumerable<Item>)(object)new Item[1]
            {
                new Item(ModContent.ItemType<CranialPendant>(), 1, 0),
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
