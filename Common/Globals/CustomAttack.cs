using Terraria;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace TheSkeletronMod.Common.Globals
{
    public class SwipeAttack : CustomAttack
    {
        public override void UseStyle(Item item, ImprovedSwingSword globalitem, Player player, Rectangle heldItemFrame)
        {
            ImprovedSwingGlobalItemPlayer modplayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            float percentDone = player.itemAnimation / (float)player.itemAnimationMax;
            float baseAngle = modplayer.data.ToRotation();
            float angle = MathHelper.ToRadians(baseAngle + globalitem.ItemSwingDegree) * player.direction;
            int direct = SwingDownWard.ToDirectionInt();
            float start = baseAngle + angle * direct;
            float end = baseAngle - angle * direct;
            float currentAngle = MathHelper.SmoothStep(start, end, percentDone);
            player.itemRotation = currentAngle;
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, currentAngle - MathHelper.PiOver2);
            player.itemRotation += player.direction > 0 ? MathHelper.PiOver4 : MathHelper.PiOver4 * 3;
            player.itemLocation = player.Center + Vector2.UnitX.RotatedBy(currentAngle) * ImprovedSwingSword.PLAYERARMLENGTH;
        }
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            int duration = player.itemAnimationMax;
            float thirdduration = duration / 3;
            float progress;
            if (player.itemAnimation < thirdduration)
            {
                progress = player.itemAnimation / thirdduration;
            }
            else
            {
                progress = (duration - player.itemAnimation) / thirdduration;
            }
            scale += MathHelper.SmoothStep(-.5f, .25f, progress);
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            Vector2 handPos = Vector2.UnitY.RotatedBy(player.compositeFrontArm.rotation);
            float length = new Vector2(item.width, item.height).Length() * player.GetAdjustedItemScale(player.HeldItem);
            Vector2 endPos = handPos;
            endPos *= length;
            handPos += player.MountedCenter;
            endPos += player.MountedCenter;
            (int X1, int X2) XVals = SkeletronUtils.Order(handPos.X, endPos.X);
            (int Y1, int Y2) YVals = SkeletronUtils.Order(handPos.Y, endPos.Y);
            hitbox = new Rectangle(XVals.X1 - 2, YVals.Y1 - 2, XVals.X2 - XVals.X1 + 2, YVals.Y2 - YVals.Y1 + 2);
        }
    }
    public class PokeAttack : CustomAttack
    {
        public float OffsetUpwardSwing = 0;
        public override void UseStyle(Item item, ImprovedSwingSword globalitem, Player player, Rectangle heldItemFrame)
        {
            ImprovedSwingGlobalItemPlayer modplayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            int direct = SwingDownWard.ToDirectionInt();
            float percentDone = player.itemAnimation / (float)player.itemAnimationMax;
            float baseAngle = modplayer.data.ToRotation();
            float angle = MathHelper.ToRadians(baseAngle + globalitem.ItemSwingDegree) * player.direction;
            float start = baseAngle + angle * direct;
            float end = baseAngle - angle * direct;
            float currentAngle = MathHelper.SmoothStep(start, end, percentDone);
            ImprovedSwingGlobalItemPlayer modPlayer = player.GetModPlayer<ImprovedSwingGlobalItemPlayer>();
            player.itemRotation = currentAngle;
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, currentAngle - MathHelper.PiOver2);
            player.itemRotation += player.direction > 0 ? MathHelper.PiOver4 : MathHelper.PiOver4 * 3;
            if (direct == -1)
            {
                modPlayer.CustomItemRotation = currentAngle;
                modPlayer.CustomItemRotation += player.direction > 0 ? MathHelper.PiOver4 * 3 : MathHelper.PiOver4;
            }
            player.itemLocation = player.Center + Vector2.UnitX.RotatedBy(currentAngle) * ImprovedSwingSword.PLAYERARMLENGTH;
        }
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            int duration = player.itemAnimationMax;
            float thirdduration = duration / 3;
            float progress;
            if (player.itemAnimation < thirdduration)
            {
                progress = player.itemAnimation / thirdduration;
            }
            else
            {
                progress = (duration - player.itemAnimation) / thirdduration;
            }
            scale += MathHelper.SmoothStep(-.5f, .25f, progress);
        }
        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            Vector2 handPos = Vector2.UnitY.RotatedBy(player.compositeFrontArm.rotation);
            float length = new Vector2(item.width, item.height).Length() * player.GetAdjustedItemScale(player.HeldItem);
            Vector2 endPos = handPos;
            endPos *= length;
            handPos += player.MountedCenter;
            endPos += player.MountedCenter;
            (int X1, int X2) XVals = SkeletronUtils.Order(handPos.X, endPos.X);
            (int Y1, int Y2) YVals = SkeletronUtils.Order(handPos.Y, endPos.Y);
            hitbox = new Rectangle(XVals.X1 - 2, YVals.Y1 - 2, XVals.X2 - XVals.X1 + 2, YVals.Y2 - YVals.Y1 + 2);
        }
        public override void ModifyDrawInfo(ref PlayerDrawSet drawinfo, Player player, Item item, ImprovedSwingGlobalItemPlayer modplayer, ImprovedSwingSword meleeItem)
        {
            if (!meleeItem.ArrayOfAttack[modplayer.AttackIndex].SwingDownWard)
            {
                for (int i = 0; i < drawinfo.DrawDataCache.Count; i++)
                {
                    if (drawinfo.DrawDataCache[i].texture == TextureAssets.Item[item.type].Value)
                    {
                        DrawData drawdata = drawinfo.DrawDataCache[i];
                        Vector2 origin = drawdata.texture.Size() * .5f;
                        drawdata.sourceRect = null;
                        drawdata.ignorePlayerRotation = true;
                        drawdata.rotation = modplayer.CustomItemRotation;
                        drawdata.position += Vector2.UnitX.RotatedBy(modplayer.CustomItemRotation) * ((origin.Length() + meleeItem.PokeAttackOffset) * drawdata.scale.X + ImprovedSwingSword.PLAYERARMLENGTH + OffsetUpwardSwing) * -player.direction;
                        drawinfo.DrawDataCache[i] = drawdata;
                    }
                }
            }
        }
        public override void PreModifyDrawInfo(ref PlayerDrawSet drawInfo, Player player)
        {
            if (SwingDownWard)
            {
                if (player.direction == -1)
                {
                    drawInfo.itemEffect = SpriteEffects.None;
                }
                else
                {
                    drawInfo.itemEffect = SpriteEffects.FlipHorizontally;
                }
            }
        }
    }
}