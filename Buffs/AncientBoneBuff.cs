using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
namespace TheSkeletronMod.Buffs
{
    class AncientBoneBuff : ModBuff
    {
        public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
        public override LocalizedText Description => base.Description;
        public override void Update(Player player, ref int buffIndex)
        {
            for (int i = 0; i < 90; i++) // I could do 360 here, instead of 90 (and then remove the "* 4" from the deg variable), and it still works well
            {
                double deg = i * 4;
                double rad = (deg) * (3.1415 / 180);
                double dist = 200;

                float x2 = player.position.X - (float)(Math.Cos(rad) * dist);
                float y2 = player.position.Y - (float)(Math.Sin(rad) * dist);
                int dust = Dust.NewDust(new Vector2(x2 - player.velocity.X, y2 - player.velocity.Y), 1, 1, DustID.Bone, 0f, 0f, 0, default(Color), 1f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}