using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
namespace TheSkeletronMod.Common.Systems
{

        public class Screenshake : ModPlayer
        {
            int timer = 0;
            public bool SmallScreenshake = false;
            bool makeTimerWork = false;



            public override void ModifyScreenPosition()
            {
                //screenshake
                if (SmallScreenshake == true)
                {
                    makeTimerWork = true;
                }
                if (makeTimerWork == true)
                {
                    int power = 6;

                    Vector2 random = new(Main.rand.Next(-power, power), Main.rand.Next(-power, power));

                    timer++;
                    if (timer > 0)
                    {
                        Main.screenPosition += random;
                    }
                    if (timer >= 10)
                    {
                        timer = 0;
                        makeTimerWork = false;
                    }
                }

            }
            public override void ResetEffects()
            {
                if (!makeTimerWork)
                {
                    SmallScreenshake = false;
                }
            }
        }
    
}
