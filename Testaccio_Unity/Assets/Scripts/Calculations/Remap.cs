using UnityEngine;

namespace Calculations
{
    public static class ExtensionMethods 
    {
 
            public static float Remap (float value, float fromMin, float fromMax, float toMin, float toMax) {
                return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
            }
    }
}
