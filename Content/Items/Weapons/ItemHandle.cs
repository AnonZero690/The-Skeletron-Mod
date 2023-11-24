using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Weapons
{
    /// <summary>
    ///This mod player should hold all the logic require for the item, if the item is shooting out the projectile, it should be doing that itself !<br/>
    ///Same with projectile unless it is a vanilla projectile then we can refer to global projectile<br/>
    ///This should only hold custom bool or data that we think should be hold/use/transfer<br/>
    ///We will name using the following format "Bone item"_"vanilla item" to assign Bone power so that it is clear to read and easy to maintain<br/>
    ///Anything that relate to actual logic and how player interact from the item could or shoulds also go in here<br/>
    /// </summary>
    public class BaseBoneModPlayer : ModPlayer
    {

    }

    /// <summary>
    /// This is a secret, I won't spoil what I will be doing with this
    /// I do not recommend to use this at the time meaning
    /// </summary>
    public abstract class BaseBoneItem : ModItem
    {
        public override sealed void SetDefaults()
        {
            base.SetDefaults();
            BoneSetDefaults();
        }
        public virtual void BoneSetDefaults()
        {

        }
        public override sealed void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            ModifySynergyToolTips(ref tooltips, Main.LocalPlayer.GetModPlayer<BaseBoneModPlayer>());
            TooltipLine line = new TooltipLine(Mod, "BaseBoneItem", "Bone item");
            tooltips.Add(line);
        }
        public virtual void ModifySynergyToolTips(ref List<TooltipLine> tooltips, BaseBoneModPlayer modplayer) { }
        public override sealed void HoldItem(Player player)
        {
            base.HoldItem(player);
            BaseBoneModPlayer modplayer = player.GetModPlayer<BaseBoneModPlayer>();
            BoneHoldItem(player, modplayer);
        }
        public virtual void BoneHoldItem(Player player, BaseBoneModPlayer modplayer) { }
        public override sealed void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
            BoneModifyShootStats(player, player.GetModPlayer<BaseBoneModPlayer>(), ref position, ref velocity, ref type, ref damage, ref knockback);
        }
        public override sealed void UpdateInventory(Player player)
        {
            base.UpdateInventory(player);
            BoneUpdateInventory(player, player.GetModPlayer<BaseBoneModPlayer>());
        }
        public virtual void BoneUpdateInventory(Player player, BaseBoneModPlayer modplayer)
        {

        }
        public virtual void BoneModifyShootStats(Player player, BaseBoneModPlayer modplayer, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

        }
        public override sealed bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            BoneShoot(player, player.GetModPlayer<BaseBoneModPlayer>(), source, position, velocity, type, damage, knockback, out bool CanShootItem);
            return CanShootItem;
        }
        public virtual void BoneShoot(Player player, BaseBoneModPlayer modplayer, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, out bool CanShootItem) { CanShootItem = true; }
        public override sealed void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, damageDone);
            BoneOnHitNPC(player, player.GetModPlayer<BaseBoneModPlayer>(), target, hit, damageDone);
        }
        public virtual void BoneOnHitNPC(Player player, BaseBoneModPlayer modplayer, NPC target, NPC.HitInfo hit, int damageDone)
        {

        }

    }
}
