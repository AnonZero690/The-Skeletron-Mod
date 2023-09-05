using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcOther
{
    public class BagOfBoneDust : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.scale = 1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 1;
            Item.noMelee = false;
        }
        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 rotationCool = (Main.MouseWorld - player.Center) / 100;
                rotationCool.X += Main.rand.Next(-20, 20) / 3;
                rotationCool.Y += Main.rand.Next(-20, 20) / 3;
                Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, rotationCool, Scale: 1.5f);
                dust1.noGravity = true;
                dust1.rotation += Main.rand.Next(-15, 15);
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Confused, 220);
        }
        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            hitbox = new Rectangle((int)player.position.X - 100, (int)player.position.Y - 75, 200, 150);
        }
    }
    public class BagOfSkullDust : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.scale = 1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.damage = 1;
            Item.noMelee = false;
        }
        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < 100; i++)
            {
                Vector2 rotationCool = (Main.MouseWorld - player.Center) / 100;
                rotationCool.X += Main.rand.Next(-20, 20) / 2;
                rotationCool.Y += Main.rand.Next(-20, 20) / 2;
                Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, rotationCool, Scale: 1.6f);
                dust1.noGravity = true;
                dust1.rotation += Main.rand.Next(-15, 15);
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Confused, 300);
        }
        public override void UseItemHitbox(Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            hitbox = new Rectangle((int)player.position.X - 125, (int)player.position.Y - 100, 250, 200);
        }
    }
}
