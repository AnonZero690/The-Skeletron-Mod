using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common;
using TheSkeletronMod.Content.Buffs;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CartArmour
{
    public class CartilageSkull : ModProjectile
    {
        int hover = 0;
        int hoverCD = 0;
        int frame = 0;
        int dustCD;
        int laserCD;
        bool descend = false;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 1; //26
            Projectile.height = 1; //36
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.minionSlots = 0;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Player p = Main.LocalPlayer;

            if (!p.HasBuff<DeadlySkull>())
            {
                Projectile.Kill();
            }
            else
            {
                if (hoverCD == 1)
                {
                    frame = 0;
                }

                if (hoverCD > 0)
                {
                    hoverCD--;
                }
                if (hoverCD == 0)
                {
                    if (p.direction == 1)
                    {
                        Projectile.spriteDirection = 1;
                    }
                    if (p.direction == -1)
                    {
                        Projectile.spriteDirection = -1;
                    }
                }

                if (dustCD > 0)
                {
                    dustCD--;
                }

                if (laserCD > 0)
                {
                    laserCD--;


                    if (laserCD > 50 && dustCD == 0)
                    {
                        dustCD = 3;
                        Vector2 spawnLoc = new Vector2(Projectile.position.X - 20 + Main.rand.Next(46), Projectile.position.Y - 20 + Main.rand.Next(46));
                        Vector2 d = (spawnLoc - Projectile.Center).SafeNormalize(Vector2.UnitX);
                        Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                        Dust dust1 = Dust.NewDustPerfect(spawnLoc, DustID.Bone, d * -2f, Scale: 1f);
                        dust1.noGravity = true;
                    }
                    if (laserCD > 5 && laserCD < 50 && dustCD == 0)
                    {
                        dustCD = 2;
                        Vector2 spawnLoc = new Vector2(Projectile.position.X - 40 + Main.rand.Next(66), Projectile.position.Y - 40 + Main.rand.Next(66));
                        Vector2 d = (spawnLoc - Projectile.Center).SafeNormalize(Vector2.UnitX);
                        Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                        Dust dust1 = Dust.NewDustPerfect(spawnLoc, DustID.Bone, d * -4f, Scale: 1f);
                        dust1.noGravity = true;
                    }
                }

                if (laserCD == 5)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                        Dust dust1 = Dust.NewDustPerfect(Projectile.Center, DustID.Bone, speed * 3, Scale: 1f);
                        dust1.noGravity = true;
                    }
                    SoundEngine.PlaySound(SoundID.MaxMana);
                }



                Projectile.position.X = p.Center.X;
                Projectile.position.Y = p.Center.Y - 85 + hover;

                if (hover < 33 && descend == false && hoverCD == 0)
                {
                    hover++;
                    hoverCD = 3;
                }
                if (hover >= 32)
                {
                    descend = true;
                }

                if (descend == true && hoverCD == 0)
                {
                    hover--;
                    hoverCD = 3;
                }

                if (hover <= 0 && descend == true)
                {
                    descend = false;
                }

                Rectangle checkBox = new Rectangle((int)Projectile.position.X - 768, (int)Projectile.position.Y - 768, 1536, 1536);
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Projectile.Colliding(checkBox, Main.npc[i].getRect()) && laserCD == 0 && !Main.npc[i].friendly && Main.npc[i].active && Main.npc[i].damage > 0)
                    {
                        
                        laserCD = 80;
                        p.GetModPlayer<SkeletronPlayer>().proj = Projectile;
                        p.GetModPlayer<SkeletronPlayer>().npc = Main.npc[i];
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Beam>(), Main.rand.Next(20, 26), 3, Main.myPlayer);
                        frame += 36;
                        hoverCD = 11;
                        if (Main.npc[i].position.X < p.position.X)
                        {
                            Projectile.spriteDirection = -1;
                        }
                        if (Main.npc[i].position.X >= p.position.X)
                        {
                            Projectile.spriteDirection = 1;
                        }
                        
                    }

                }

            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("TheSkeletronMod/projectiles/Calcprojs/CartArmour/CartilageSkull2");

            SpriteEffects spriteEffects = Projectile.spriteDirection == -1  ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            int f = texture.Height / Main.projFrames[Projectile.type];


            Rectangle sourceRect = new Rectangle(0, frame, texture.Width, 36);
            Vector2 origin = sourceRect.Size() / 2f;

            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRect, new Color(219, 218, 216), Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}