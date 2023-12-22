using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Items.Placeables;
using TheSkeletronMod.Content.Items.Placeables.Bars;
using TheSkeletronMod.Content.Items.Weapons.Calcium.CalcOther;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcOther
{
    public class BagOfBoneDust : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.scale = 1.2f;
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
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 3)
                .AddIngredient(ItemID.Silk, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
    public class BagOfSkullDust : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.scale = 1.2f;
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
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<BagOfBoneDust>(), 1)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 5)
                .AddIngredient(ModContent.ItemType<LeadBone>(), 10)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 5)
                .AddIngredient(ItemID.SkeletronMask, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
