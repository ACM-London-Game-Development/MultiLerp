using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to invoke coroutines to Lerp a Vector3, Vector2, Rotation or Color
/// Coroutines run on the calling Monobehaviour so this script does not need to be included in your scene 
/// </summary>
public class MultiLerp : MonoBehaviour
{
    /// <summary>
    /// Lerps a Transform position from Vector3 start to Vector3 end over duration time-period
    /// </summary>
    /// <param name="obj"> The Transform to Lerp </param>
    /// <param name="start"> The starting position </param>
    /// <param name="end"> The end position </param>
    /// <param name="duration"> The duration for the Lerp to take </param>
    /// <param name="me"> A reference to the Monobehaviour this is called from (i.e. this). The Lerp Coroutine is run on that gameObject </param>
    /// <param name="callbackMethod"> (optional) The name of any callback Method you wish to be invoked at the end of the Lerp </param>
    public static void DoLerp(Transform obj, Vector3 start, Vector3 end, float duration, MonoBehaviour me, string callbackMethod = "")
    {
        me.StartCoroutine(CoLerp(obj, start, end, duration, me, lerpDone =>
        {
            if (lerpDone)
            {
                //Debug.Log("CallBack Lerp Done");
                if (callbackMethod != "")
                {
                    me.Invoke(callbackMethod, 0f);
                }
            }
        }));
    }

    /// <summary>
    /// Lerps a Transform position from Vector2 start to Vector2 end over duration time-period
    /// </summary>
    /// <param name="obj"> The Transform to Lerp </param>
    /// <param name="start"> The starting position </param>
    /// <param name="end"> The end position </param>
    /// <param name="duration"> The duration for the Lerp to take </param>
    /// <param name="me"> A reference to the Monobehaviour this is called from (i.e. this). The Lerp Coroutine is run on that gameObject </param>
    /// <param name="callbackMethod"> (optional) The name of any callback Method you wish to be invoked at the end of the Lerp </param>
    public static void DoLerp(Transform obj, Vector2 start, Vector2 end, float duration, MonoBehaviour me, string callbackMethod = "")
    {
        me.StartCoroutine(CoLerp(obj, start, end, duration, me, lerpDone =>
        {
            if (lerpDone)
            {
                //Debug.Log("CallBack Lerp Done");
                if (callbackMethod != "")
                {
                    me.Invoke(callbackMethod, 0f);
                }
            }
        }));
    }

    /// <summary>
    /// Lerps a Transform rotation from Quaternion start to Quaternion end over duration time-period
    /// </summary>
    /// <param name="obj"> The Transform to Lerp </param>
    /// <param name="start"> The starting rotation </param>
    /// <param name="end"> The end rotation </param>
    /// <param name="duration"> The duration for the Lerp to take </param>
    /// <param name="me"> A reference to the Monobehaviour this is called from (i.e. this). The Lerp Coroutine is run on that gameObject </param>
    /// <param name="callbackMethod"> (optional) The name of any callback Method you wish to be invoked at the end of the Lerp </param>
    public static void DoLerp(Transform obj, Quaternion start, Quaternion end, float duration, MonoBehaviour me, string callbackMethod = "")
    {
        me.StartCoroutine(CoLerp(obj, start, end, duration, me, lerpDone =>
        {
            if (lerpDone)
            {
                //Debug.Log("CallBack Lerp Done");
                if (callbackMethod != "")
                {
                    me.Invoke(callbackMethod, 0f);
                }
            }
        }));
    }

    /// <summary>
    /// Lerps a Material Color from Color start to Color end over duration time-period
    /// </summary>
    /// <param name="mat"> The Material whose color to Lerp </param>
    /// <param name="start"> The starting Color </param>
    /// <param name="end"> The end color </param>
    /// <param name="duration"> The duration for the Lerp to take </param>
    /// <param name="me"> A reference to the Monobehaviour this is called from (i.e. this). The Lerp Coroutine is run on that gameObject </param>
    /// <param name="callbackMethod"> (optional) The name of any callback Method you wish to be invoked at the end of the Lerp </param>
    public static void DoLerp(Material mat, Color start, Color end, float duration, MonoBehaviour me, string callbackMethod = "")
    {
        me.StartCoroutine(CoLerp(mat, start, end, duration, me, lerpDone =>
        {
            if (lerpDone)
            {
                //Debug.Log("CallBack Lerp Done");
                if (callbackMethod != "")
                {
                    me.Invoke(callbackMethod, 0f);
                }
            }
        }));
    }



    public static IEnumerator CoLerp(Transform obj, Vector3 start, Vector3 end, float duration, MonoBehaviour me, System.Action<bool> callback)
    {
        float perc = 0f;
        float currentLerpTime = 0f;

        while (perc < 1.0f)
        {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / duration;
            obj.position = Vector3.Lerp(start, end, perc);
            yield return null;
        }
        callback(true);
    }

    public static IEnumerator CoLerp(Transform obj, Vector2 start, Vector2 end, float duration, MonoBehaviour me, System.Action<bool> callback)
    {
        float perc = 0f;
        float currentLerpTime = 0f;

        while (perc < 1.0f)
        {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / duration;
            obj.position = Vector2.Lerp(start, end, perc);
            yield return null;
        }
        callback(true);
    }

    public static IEnumerator CoLerp(Transform obj, Quaternion start, Quaternion end, float duration, MonoBehaviour me, System.Action<bool> callback)
    {
        float perc = 0f;
        float currentLerpTime = 0f;

        while (perc < 1.0f)
        {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / duration;
            obj.rotation = Quaternion.Slerp(start, end, perc);
            yield return null;
        }
        callback(true);
    }

    public static IEnumerator CoLerp(Material mat, Color start, Color end, float duration, MonoBehaviour me, System.Action<bool> callback)
    {
        float perc = 0f;
        float currentLerpTime = 0f;

        while (perc < 1.0f)
        {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / duration;
            mat.color = Color.Lerp(start, end, perc);
            yield return null;
        }
        callback(true);
    }
}
