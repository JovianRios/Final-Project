using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.05F;
    public float slowdownLength = 2f;
    public int score;

    private void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion()
    {
        const int V = 200;
        bool v1 = score >= V;
        bool v = v1;
        if (v)
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f;

        }
    }
}
