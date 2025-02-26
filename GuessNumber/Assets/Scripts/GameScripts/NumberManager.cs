using UnityEngine;

public class NumberManager : MonoBehaviour
{
    public static NumberManager s_inst;
    public int randomNumber { private set; get; }
    public int numOfAttempts { private set; get; } = 1;
    public int minRandom { private set; get; } = 0;
    public int maxRandom { private set; get; } = 10;
    public int reward { private set; get; } = 0;
    public int loss { private set; get; } = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        s_inst = this;
    }

    public void GenerateRandomNumber()
    {
        randomNumber = Random.Range(minRandom, maxRandom);
    }

    public void ChangeMinRandom(int num)
    {
        minRandom = num < maxRandom ? num : 0;
    }
    public void ChangeMaxRandom(int num)
    {
        maxRandom = num > minRandom ? num : minRandom + 10;
    }
    public void ChangeAttempts(int num)
    {
        numOfAttempts = num;
    }
    public void ChangeReward(int num)
    {
        reward = num;
    }
    public void ChangeLoss(int num)
    {
        loss = num;
    }
}
