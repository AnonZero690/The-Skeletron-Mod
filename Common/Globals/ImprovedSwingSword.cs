using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee;

namespace TheSkeletronMod.Common.Globals
{
    //public enum CustomUseStyle
    //{
    //    DefaultNoCustomSwing,
    //    SwipeAttack,
    //    PokeAttack,
    //    CircleAttack,
    //    SpearAttack,
    //}
    public abstract class CustomAttack
    {
        public bool SwingDownWard = false;
        public CustomAttack()
        {
        }
        public CustomAttack(bool SwingDownWard)
        {

        }
        public virtual void UseStyle(Item item, ImprovedSwingSword globalitem, Player player, Rectangle heldItemFrame) { }
        public virtual void ModifyItemScale(Item item, Player player, ref float scale) { }
        public virtual void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox) { }
        public virtual void ModifyDrawInfo(ref PlayerDrawSet drawinfo, Player player, Item item, ImprovedSwingGlobalItemPlayer modplayer, ImprovedSwingSword meleeItem) { }
        public virtual void PreModifyDrawInfo(ref PlayerDrawSet drawInfo, Player player) { }
    }
    /// <summary>
    /// To see implementation of this, please check <br/>
    /// <see cref="SawboneSword.SetDefaults"/> or <see cref="BoneSword.SetDefaults"/> to see how to use this
    /// </summary>
    public class ImprovedSwingSword : GlobalItem
    {
        public float PokeAttackOffset = 0;
        public override bool InstancePerEntity => true;
        public float ItemSwingDegree = 120;
        public const float PLAYERARMLENGTH = 12f;
        /// <summary>
        /// Use this to set up your own attack swing<br/>
        /// Q : Why not use List ?<br/>
        /// A : Be responsible :>
        /// Also Attack Index are automatically managed, so don't bother with it
        /// </summary>
        public CustomAttack[] ArrayOfAttack = new CustomAttack[] { };

        /// <summary>
        /// Don't mess with this fr
        /// </summary>
        public override bool? UseItem(Item item, Player player)
        {
            if (ArrayOfAttack == null || ArrayOfAttack.Length <= 0 || item.type != player.HeldItem.type)
                return base.UseItem(item, player);
            if (player.ItemAnimationJustStarted)
            {
                ImprovedSwingGlobalItemPlayer modplayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
                if (++modplayer.AttackIndex >= ArrayOfAttack.Length)
                {
                    modplayer.AttackIndex = 0;
                }
            }
            return base.UseItem(item, player);
        }
        public override void UseStyle(Item item, Player player, Rectangle heldItemFrame)
        {
            ImprovedSwingGlobalItemPlayer modPlayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            if (ArrayOfAttack == null || ArrayOfAttack.Length <= 0 || item.type != player.HeldItem.type || modPlayer.AttackIndex >= ArrayOfAttack.Length)
                return;
            ArrayOfAttack[modPlayer.AttackIndex].UseStyle(item, this, player, heldItemFrame);
            //if (ArrayOfAttack[modPlayer.AttackIndex].style == CustomUseStyle.SwipeAttack)
            //{
            //    SwipeAttack(player, modplayer, ItemSwingDegree, ArrayOfAttack[modPlayer.AttackIndex].SwingDownWard.BoolOne());
            //}
            //if (ArrayOfAttack[modPlayer.AttackIndex].style == CustomUseStyle.PokeAttack)
            //{
            //    PokeAttack(player, modplayer, ItemSwingDegree, ArrayOfAttack[modPlayer.AttackIndex].SwingDownWard.BoolOne());
            //}
            //if (ArrayOfAttack[modPlayer.AttackIndex].style == CustomUseStyle.CircleAttack)
            //{
            //    CircleSwingAttack(player);
            //}
        }
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            ImprovedSwingGlobalItemPlayer modPlayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            if (ArrayOfAttack == null || ArrayOfAttack.Length <= 0 || item.type != player.HeldItem.type || modPlayer.AttackIndex >= ArrayOfAttack.Length)
                return;
            ArrayOfAttack[modPlayer.AttackIndex].ModifyItemScale(item, player, ref scale);
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            ImprovedSwingGlobalItemPlayer modPlayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            if (ArrayOfAttack == null || ArrayOfAttack.Length <= 0 || item.type != player.HeldItem.type || modPlayer.AttackIndex >= ArrayOfAttack.Length)
                return;
            ArrayOfAttack[modPlayer.AttackIndex].UseItemHitbox(item, player, ref hitbox, ref noHitbox);
        }
    }
    /// <summary>
    /// DO NOT FUCK WITH THIS
    /// </summary>
    public class MeleeOverhaulSystem : ModSystem
    {
        public override void Load()
        {
            base.Load();
            On_PlayerDrawLayers.DrawPlayer_RenderAllLayers += On_PlayerDrawLayers_DrawPlayer_RenderAllLayers;
        }

        private void On_PlayerDrawLayers_DrawPlayer_RenderAllLayers(On_PlayerDrawLayers.orig_DrawPlayer_RenderAllLayers orig, ref PlayerDrawSet drawinfo)
        {
            Player player = Main.LocalPlayer;
            Item item = player.HeldItem;
            if (player.TryGetModPlayer(out ImprovedSwingGlobalItemPlayer modplayer)
                && item.TryGetGlobalItem(out ImprovedSwingSword meleeItem)
                && meleeItem.ArrayOfAttack != null && modplayer.AttackIndex < meleeItem.ArrayOfAttack.Length)
            {
                meleeItem.ArrayOfAttack[modplayer.AttackIndex].ModifyDrawInfo(ref drawinfo, player, item, modplayer, meleeItem);
            }
            orig.Invoke(ref drawinfo);
        }
    }
    public class ImprovedSwingGlobalItemPlayer : ModPlayer
    {
        public Vector2 data = Vector2.Zero;
        public Vector2 mouseLastPosition = Vector2.Zero;
        public float CustomItemRotation = 0;
        public int AttackIndex = 0;
        public Item item = null;
        public override void PostUpdate()
        {
            if (item == null)
            {
                item = Player.HeldItem;
            }
            else if (item.type != Player.HeldItem.type)
            {
                AttackIndex = 0;
                item = Player.HeldItem;
            }
            if (item.TryGetGlobalItem(out ImprovedSwingSword meleeItem))
            {
                if (meleeItem.ArrayOfAttack == null 
                    || meleeItem.ArrayOfAttack.Length <= 0 
                    || item.type != Player.HeldItem.type 
                    || AttackIndex >= meleeItem.ArrayOfAttack.Length 
                    || Player.HeldItem.noMelee)
                    return;
            }
            if (Player.ItemAnimationJustStarted)
            {
                data = (Main.MouseWorld - Player.MountedCenter).SafeNormalize(Vector2.Zero);
            }
            if (Player.ItemAnimationActive)
            {
                Player.direction = data.X > 0 ? 1 : -1;
            }
            Player.attackCD = 0;
            for (int i = 0; i < Player.meleeNPCHitCooldown.Length; i++)
            {
                if (Player.meleeNPCHitCooldown[i] > 0)
                {
                    Player.meleeNPCHitCooldown[i]--;
                }
            }
        }
        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            base.ModifyDrawInfo(ref drawInfo);
            Item item = Player.HeldItem;
            if (item.TryGetGlobalItem(out ImprovedSwingSword meleeItem))
            {
                if (meleeItem.ArrayOfAttack != null && meleeItem.ArrayOfAttack.Length <= AttackIndex)
                {
                    meleeItem.ArrayOfAttack[AttackIndex].PreModifyDrawInfo(ref drawInfo, Player);
                }
            }
        }
    }
}
