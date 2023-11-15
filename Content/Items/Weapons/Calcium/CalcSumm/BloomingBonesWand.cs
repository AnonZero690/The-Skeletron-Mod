using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Buffs.SummonBuffs;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcSummProj.BloominBones;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcSumm
{
    public class BloomingBonesWand : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.Safe);
        public override void SetDefaults()
        {
            Item.Size = new Vector2(58, 62);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.damage = 30;
            Item.knockBack = 0;
            Item.noMelee = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.mana = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item44;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.buffType = ModContent.BuffType<FullCursedBloom>();
            Item.shoot = ModContent.ProjectileType<BloomingBonesSProj>();
        }
    public override bool MagicPrefix()
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
            int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2, true);
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
            ref float knockback)
        {
            position = Main.MouseWorld;
        }
    }
}
