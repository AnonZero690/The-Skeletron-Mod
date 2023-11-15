using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace TheSkeletronMod.Common.Utils
{
    public static partial class SkeletronUtils
    {
        public static void ProjectileDefaultDrawInfo(this Projectile projectile, out Texture2D texture, out Vector2 origin)
        {
            Main.instance.LoadProjectile(projectile.type);
            texture = TextureAssets.Projectile[projectile.type].Value;
            origin = new Vector2(texture.Width * 0.5f, projectile.height * 0.5f);
        }
        public static void DrawTrail(this Projectile projectile, Color lightColor, float ManualScaleAccordinglyToLength = 0)
        {
            projectile.ProjectileDefaultDrawInfo(out Texture2D texture, out Vector2 origin);
            if (ProjectileID.Sets.TrailingMode[projectile.type] != 2)
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    Main.EntitySpriteDraw(texture, drawPos, null, color, projectile.rotation, origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
            else
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    Main.EntitySpriteDraw(texture, drawPos, null, color, projectile.oldRot[k], origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
        }
        public static void DrawTrailWithoutColorAdjustment(this Projectile projectile, Color lightColor, float ManualScaleAccordinglyToLength = 0)
        {
            projectile.ProjectileDefaultDrawInfo(out Texture2D texture, out Vector2 origin);
            if (ProjectileID.Sets.TrailingMode[projectile.type] != 2)
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Main.EntitySpriteDraw(texture, drawPos, null, lightColor, projectile.rotation, origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
            else
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Main.EntitySpriteDraw(texture, drawPos, null, lightColor, projectile.oldRot[k], origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
        }
        public static void DrawTrailWithColorAdjustmentHaveFade(this Projectile projectile, Color lightColor, float ManualScaleAccordinglyToLength = 0)
        {
            projectile.ProjectileDefaultDrawInfo(out Texture2D texture, out Vector2 origin);
            if (ProjectileID.Sets.TrailingMode[projectile.type] != 2)
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Main.EntitySpriteDraw(texture, drawPos, null, lightColor, projectile.rotation, origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
            else
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, projectile.gfxOffY);
                    Main.EntitySpriteDraw(texture, drawPos, null, lightColor, projectile.oldRot[k], origin, projectile.scale - k * ManualScaleAccordinglyToLength, SpriteEffects.None, 0);
                }
            }
        }
    }
}