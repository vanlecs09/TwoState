using UnityEngine;

public sealed class UnityTimeService: ITimeService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public float GetFixedDeltaTime()
    {
        return Time.fixedDeltaTime;
    }
}
