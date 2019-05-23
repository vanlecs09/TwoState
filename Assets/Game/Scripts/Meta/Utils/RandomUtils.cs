using UnityEngine;
using System.Collections;

// namespace Shepherd
// {
public class RandomUtility
{
    public static float Randfloat()
    {
        return Random.Range(0.0f, 1.0f);
    }

    public static float RandomClamped()
    {
        return Randfloat() - Randfloat();
    }

    public static int RandInt(int x, int y)
    {
        return 0;
    }
}
