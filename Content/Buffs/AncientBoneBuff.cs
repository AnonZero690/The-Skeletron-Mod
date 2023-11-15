using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Buffs
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
            double dist = 200;
            for (int i = 0; i < 90; i++) // I could do 360 here, instead of 90 (and then remove the "* 4" from the deg variable), and it still works well
            {
                double deg = i * 4;
                double rad = (deg) * (Math.PI / 180);
                float x2 = player.Center.X - (float)(Math.Cos(rad) * dist);
                float y2 = player.Center.Y - (float)(Math.Sin(rad) * dist);
                int dust = Dust.NewDust(new Vector2(x2, y2), 3, 3, DustID.BoneTorch, 0f, 0f, 0, new Color(175, 160, 120), 1f);
                Main.dust[dust].noGravity = true;
                
            }
            for (int i = 0; i<200; i++){
                if (((Main.npc[i].Center.X-player.Center.X)*(Main.npc[i].Center.X-player.Center.X))+((Main.npc[i].Center.Y-player.Center.Y)*(Main.npc[i].Center.Y-player.Center.Y))<(dist*dist)){
                    Main.npc[i].AddBuff(ModContent.BuffType<BonedDebuff>(),180);
                }
            }
        }
    }
}