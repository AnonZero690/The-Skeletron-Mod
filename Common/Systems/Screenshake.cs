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

        public int ScreenShake = 0;

        public override void ModifyScreenPosition()
        {
            if (ScreenShake > 0)
            {
                Main.screenPosition += new Vector2(Main.rand.Next(-1, 1), Main.rand.Next(-1, 1));
                ScreenShake--;
            }

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
