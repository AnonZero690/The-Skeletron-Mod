using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Items.Accessories
{
    public class BoneConvertor : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.Bone);
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.accessory = true;
        }
        public override void UpdateEquip(Player player)
        {
            BoneConvertorModPlayer modplayer = player.GetModPlayer<BoneConvertorModPlayer>();
            modplayer.BoneConvertor = true;
        }
    }
    public class BoneConvertorModPlayer : ModPlayer
    {
        public bool BoneConvertor = false;
        public override void ResetEffects()
        {
            BoneConvertor = false;
        }
    }
    public class BoneConvertorGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool IsFromNonHostileSource = false;
        public int timer = 0;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.friendly && !projectile.hostile && !projectile.minion)
                if (source is EntitySource_ItemUse || source is EntitySource_ItemUse_WithAmmo)
                {
                    IsFromNonHostileSource = true;
                }
        }
        public override void PostAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            BoneConvertorModPlayer modplayer = player.GetModPlayer<BoneConvertorModPlayer>();
            if (modplayer.BoneConvertor && IsFromNonHostileSource && ++timer >= 20)
            {
                timer = 0;
                int proj = Projectile.NewProjectile(projectile.GetSource_FromAI(), projectile.Center, Main.rand.NextVector2Circular(5f, 5f), ProjectileID.Bone, projectile.damage, projectile.knockBack, projectile.owner);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
            }
        }
    }
}
