using System;
using Microsoft.Xna.Framework;

namespace TheSkeletronMod.Common.Utils;

public static class Easing
{
    public static float InExpo(float t) => (float)Math.Pow(2, 5 * (t - 1));
    public static float OutExpo(float t) => 1 - InExpo(1 - t);

    public static float InOutExpo(float t)
    {
        if (t < 0.5) return InExpo(t * 2) * .5f;
        return 1 - InExpo((1 - t) * 2) * .5f;
    }

    public static float InExpo(float t, float strength) => (float)Math.Pow(2, strength * (t - 1));
    public static float OutExpo(float t, float strength) => 1 - InExpo(1 - t, strength);

    public static float InOutExpo(float t, float strength)
    {
        if (t < 0.5) return InExpo(t * 2, strength) * .5f;
        return 1 - InExpo((1 - t) * 2, strength) * .5f;
    }

    public static float InSine(float t) => (float)-Math.Cos(t * MathHelper.PiOver2);
    public static float OutSine(float t) => (float)Math.Sin(t * MathHelper.PiOver2);
    public static float InOutSine(float t) => (float)(Math.Cos(t * Math.PI) - 1) * -.5f;

    public static float InBack(float t)
    {
        float s = 1.70158f;
        return t * t * ((s + 1) * t - s);
    }

    public static float OutBack(float t) => 1 - InBack(1 - t);

    public static float InOutBack(float t)
    {
        if (t < 0.5) return InBack(t * 2) * .5f;
        return 1 - InBack((1 - t) * 2) * .5f;
    }
}