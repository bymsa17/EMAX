﻿using System;
using UnityEngine;
using System.Collections;

/// </summary>
/// <param name="t">Current time in seconds.</param>
/// <param name="b">Starting value.</param>
/// <param name="c">Final value.</param>
/// <param name="d">Duration of animation.</param>
/// <returns>The correct value.</returns>

public static class Easing
{
    #region Linear

    /// Easing equation function for a simple linear tweening, with no easing.	
    public static float Linear(float t, float b, float c, float d)
    {
        return c * t / d + b;
    }

    #endregion

    #region Expo

    /// Easing equation function for an exponential (2^t) easing out: 
    /// decelerating from zero velocity.
    public static float ExpoEaseOut(float t, float b, float c, float d)
    {
        return (t == d) ? b + c : (float)(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
    }

    /// Easing equation function for an exponential (2^t) easing in: 
    /// accelerating from zero velocity.

    public static float ExpoEaseIn(float t, float b, float c, float d)
    {
        return (t == 0) ? b : (float)(c * Math.Pow(2, 10 * (t / d - 1)) + b);
    }

    /// Easing equation function for an exponential (2^t) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float ExpoEaseInOut(float t, float b, float c, float d)
    {
        if(t == 0)
            return b;

        if(t == d)
            return b + c;

        if((t /= d / 2) < 1)
            return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);

        return (float)(c / 2 * (-Math.Pow(2, -10 * --t) + 2) + b);
    }

    /// Easing equation function for an exponential (2^t) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float ExpoEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return ExpoEaseOut(t * 2, b, c / 2, d);

        return ExpoEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Circular

    /// Easing equation function for a circular (sqrt(1-t^2)) easing out: 
    /// decelerating from zero velocity.

    public static float CircEaseOut(float t, float b, float c, float d)
    {
        return (float)(c * Math.Sqrt(1 - (t = t / d - 1) * t) + b);
    }

    /// Easing equation function for a circular (sqrt(1-t^2)) easing in: 
    /// accelerating from zero velocity.

    public static float CircEaseIn(float t, float b, float c, float d)
    {
        return (float)(-c * (Math.Sqrt(1 - (t /= d) * t) - 1) + b);
    }

    /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float CircEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);

        return (float)(c / 2 * (Math.Sqrt(1 - (t -= 2) * t) + 1) + b);
    }

    /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float CircEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return CircEaseOut(t * 2, b, c / 2, d);

        return CircEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Quad

    /// Easing equation function for a quadratic (t^2) easing out: 
    /// decelerating from zero velocity.

    public static float QuadEaseOut(float t, float b, float c, float d)
    {
        return -c * (t /= d) * (t - 2) + b;
    }

    /// Easing equation function for a quadratic (t^2) easing in: 
    /// accelerating from zero velocity.

    public static float QuadEaseIn(float t, float b, float c, float d)
    {
        return c * (t /= d) * t + b;
    }

    /// Easing equation function for a quadratic (t^2) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float QuadEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return c / 2 * t * t + b;

        return -c / 2 * ((--t) * (t - 2) - 1) + b;
    }

    /// Easing equation function for a quadratic (t^2) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float QuadEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return QuadEaseOut(t * 2, b, c / 2, d);

        return QuadEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Sine

    /// Easing equation function for a sinusoidal (sin(t)) easing out: 
    /// decelerating from zero velocity.

    public static float SineEaseOut(float t, float b, float c, float d)
    {
        return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
    }

    /// Easing equation function for a sinusoidal (sin(t)) easing in: 
    /// accelerating from zero velocity.

    public static float SineEaseIn(float t, float b, float c, float d)
    {
        return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
    }

    /// Easing equation function for a sinusoidal (sin(t)) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float SineEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return (float)(c / 2 * (Math.Sin(Math.PI * t / 2)) + b);

        return (float)(-c / 2 * (Math.Cos(Math.PI * --t / 2) - 2) + b);
    }

    /// Easing equation function for a sinusoidal (sin(t)) easing in/out: 
    /// deceleration until halfway, then acceleration.

    public static float SineEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return SineEaseOut(t * 2, b, c / 2, d);

        return SineEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Cubic

    /// Easing equation function for a cubic (t^3) easing out: 
    /// decelerating from zero velocity.

    public static float CubicEaseOut(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * t + 1) + b;
    }

    /// Easing equation function for a cubic (t^3) easing in: 
    /// accelerating from zero velocity.

    public static float CubicEaseIn(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t + b;
    }

    /// Easing equation function for a cubic (t^3) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float CubicEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return c / 2 * t * t * t + b;

        return c / 2 * ((t -= 2) * t * t + 2) + b;
    }

    /// Easing equation function for a cubic (t^3) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float CubicEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return CubicEaseOut(t * 2, b, c / 2, d);

        return CubicEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Quartic

    /// Easing equation function for a quartic (t^4) easing out: 
    /// decelerating from zero velocity.

    public static float QuartEaseOut(float t, float b, float c, float d)
    {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    }

    /// Easing equation function for a quartic (t^4) easing in: 
    /// accelerating from zero velocity.

    public static float QuartEaseIn(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t * t + b;
    }

    /// Easing equation function for a quartic (t^4) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float QuartEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return c / 2 * t * t * t * t + b;

        return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
    }

    /// Easing equation function for a quartic (t^4) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float QuartEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return QuartEaseOut(t * 2, b, c / 2, d);

        return QuartEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Quintic

    /// Easing equation function for a quintic (t^5) easing out: 
    /// decelerating from zero velocity.

    public static float QuintEaseOut(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
    }

    /// Easing equation function for a quintic (t^5) easing in: 
    /// accelerating from zero velocity.

    public static float QuintEaseIn(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t * t * t + b;
    }

    /// Easing equation function for a quintic (t^5) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float QuintEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) < 1)
            return c / 2 * t * t * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
    }

    /// Easing equation function for a quintic (t^5) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float QuintEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return QuintEaseOut(t * 2, b, c / 2, d);
        return QuintEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Elastic

    /// Easing equation function for an elastic (exponentially decaying sine wave) easing out: 
    /// decelerating from zero velocity.

    public static float ElasticEaseOut(float t, float b, float c, float d)
    {
        if((t /= d) == 1)
            return b + c;

        float p = d * .3f;
        float s = p / 4;

        return (float)(c * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b);
    }

    /// Easing equation function for an elastic (exponentially decaying sine wave) easing in: 
    /// accelerating from zero velocity.

    public static float ElasticEaseIn(float t, float b, float c, float d)
    {
        if((t /= d) == 1)
            return b + c;

        float p = d * .3f;
        float s = p / 4;

        return (float)(-(c * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b);
    }

    /// Easing equation function for an elastic (exponentially decaying sine wave) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float ElasticEaseInOut(float t, float b, float c, float d)
    {
        if((t /= d / 2) == 2)
            return b + c;

        float p = d * (.3f * 1.5f);
        float s = p / 4;

        if(t < 1)
            return (float)(-.5f * (c * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b);
        return (float)(c * Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * .5f + c + b);
    }

    /// Easing equation function for an elastic (exponentially decaying sine wave) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float ElasticEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return ElasticEaseOut(t * 2, b, c / 2, d);
        return ElasticEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Bounce

    /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out: 
    /// decelerating from zero velocity.

    public static float BounceEaseOut(float t, float b, float c, float d)
    {
        if((t /= d) < (1 / 2.75f))
            return c * (7.5625f * t * t) + b;
        else if(t < (2 / 2.75f))
            return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + .75f) + b;
        else if(t < (2.5f / 2.75f))
            return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + .9375f) + b;
        else
            return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
    }

    /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in: 
    /// accelerating from zero velocity.

    public static float BounceEaseIn(float t, float b, float c, float d)
    {
        return c - BounceEaseOut(d - t, 0, c, d) + b;
    }

    /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float BounceEaseInOut(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return BounceEaseIn(t * 2, 0, c, d) * .5f + b;
        else
            return BounceEaseOut(t * 2 - d, 0, c, d) * .5f + c * .5f + b;
    }

    /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float BounceEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return BounceEaseOut(t * 2, b, c / 2, d);
        return BounceEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion

    #region Back

    /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out: 
    /// decelerating from zero velocity.

    public static float BackEaseOut(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * ((1.70158f + 1) * t + 1.70158f) + 1) + b;
    }

    /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in: 
    /// accelerating from zero velocity.

    public static float BackEaseIn(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * ((1.70158f + 1) * t - 1.70158f) + b;
    }

    /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in/out: 
    /// acceleration until halfway, then deceleration.

    public static float BackEaseInOut(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        if((t /= d / 2) < 1)
            return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
    }

    /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out/in: 
    /// deceleration until halfway, then acceleration.

    public static float BackEaseOutIn(float t, float b, float c, float d)
    {
        if(t < d / 2)
            return BackEaseOut(t * 2, b, c / 2, d);
        return BackEaseIn((t * 2) - d, b + c / 2, c / 2, d);
    }

    #endregion
}