using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace TheSkeletronMod.Common.Utils
{
    public static partial class SkeletronUtils
    {
        /// <summary>
        /// Use this assuming the code files and texture files are in the same folder and have the same name<br/>
        /// which is what you should do
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetEntityTexture<T>() where T : class
        {
            var type = typeof(T);
            string NameSpace = type.Namespace;
            return NameSpace.Replace(".", "/") + "/" + type.Name;
        }
        /// <summary>
        /// Use this assuming the code files and texture files are in the same folder and have the same name<br/>
        /// which is what you should do
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="altName"></param>
        /// <returns></returns>
        public static string GetTheSameTextureAs<T>(string altName = "") where T : class
        {
            var type = typeof(T);
            if (string.IsNullOrEmpty(altName))
            {
                altName = type.Name;
            }
            string NameSpace = type.Namespace;
            return NameSpace.Replace(".", "/") + "/" + altName;
        }
        public static string GetVanillaTexture<T>(int EntityType) where T : class => $"Terraria/Images/{typeof(T).Name}_{EntityType}";
        public static bool IsAnyVanillaBossAlive()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.boss && npc.active)
                {
                    return true;
                }
                else if ((npc.type == NPCID.EaterofWorldsBody
                    || npc.type == NPCID.EaterofWorldsHead
                    || npc.type == NPCID.EaterofWorldsTail)
                    && npc.active)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Spawn combat text above player without the random Y position
        /// </summary>
        /// <param name="location">player hitbox</param>
        /// <param name="color"></param>
        /// <param name="combatMessage"></param>
        /// <param name="offsetposY"></param>
        /// <param name="dramatic"></param>
        /// <param name="dot"></param>
        public static void CombatTextRevamp(Rectangle location, Color color, string combatMessage, int offsetposY = 0, int timeleft = 30, bool dramatic = false, bool dot = false)
        {
            int drama = 0;
            if (dramatic)
            {
                drama = 1;
            }
            int text = CombatText.NewText(new Rectangle(), color, combatMessage, dramatic, dot);
            CombatText cbtext = Main.combatText[text];
            Vector2 vector = FontAssets.CombatText[drama].Value.MeasureString(cbtext.text);
            cbtext.position.X = location.X + location.Width * 0.5f - vector.X * 0.5f;
            cbtext.position.Y = location.Y + offsetposY + location.Height * 0.25f - vector.Y * 0.5f;
            cbtext.lifeTime += timeleft;
        }
        /// <summary>
        /// Use to order 2 values from smallest to biggest
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static (int, int) Order(float v1, float v2) => v1 < v2 ? ((int)v1, (int)v2) : ((int)v2, (int)v1);
        public static bool AnyNPCs(int type) => NPC.CountNPCS(type) > 0;
        public static NPC GetNearestNPC(this Vector2 position, float distance)
        {
            NPC nearest = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                float dist = Main.npc[i].Distance(position);
                if (Main.npc[i].active && dist < distance)
                {
                    nearest = Main.npc[i];
                    distance = dist;
                }
            }
            return nearest;
        }
        public static NPC GetNearestValidTarget(this Vector2 position, float distance)
        {
            NPC nearest = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                float dist = Main.npc[i].Distance(position);
                if (Main.npc[i].active
                    && dist < distance
                    && Main.npc[i].CanBeChasedBy()
                    && !Main.npc[i].friendly)
                {
                    nearest = Main.npc[i];
                    distance = dist;
                }
            }

            return nearest;
        }
        public static List<NPC> GetNPCsInRange(this Vector2 position, float distance)
        {
            return Main.npc.Where(npc =>
                npc.type != NPCID.TargetDummy
            && npc.CanBeChasedBy()
            && npc.Distance(position) < distance).ToList();
        }

        public static Color MultiColor(Color[] colors, float f)
        {
            int start = (int)(f * (colors.Length - 1));
            int end = (start + 1) % colors.Length;
            if (end >= colors.Length)
            {
                end = start;
            }
            float prog = f * (colors.Length - 1) - start;
            return Color.Lerp(colors[start], colors[end], prog);
        }
    }
}