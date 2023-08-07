using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace TheSkeletronMod.Items.Weapons.Magic
{

    public class SkeleWand : ModItem
    {
        public int MIN = -20;
        public int MAX = -20;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.ItemDefaultMagic(40, 40, 20, 1f, 25, 25, ItemUseStyleID.Shoot, ProjectileID.BoneGloveProj, 9f, 5, true);
            Item.useTurn = true;
            Item.DamageType = DamageClass.Magic;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.DD2_SkeletonSummoned;
            Item.value = Item.buyPrice(silver: 11);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld + new Vector2(Main.rand.Next(-300, 300) * -player.direction, -1000);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, (Main.MouseWorld - position).SafeNormalize(Vector2.Zero) * Item.shootSpeed, type, damage, knockback, player.whoAmI);
            return false;
        }
        public override bool OnPickup(Player player)
        {
            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            var offset = new Vector2(1, 0);
            return offset;
        }
    }
}