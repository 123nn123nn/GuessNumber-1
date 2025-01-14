using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TMP_Text MainText;
    public TMP_Text AttemptsText;
    public TMP_Text NumText;
    public TMP_InputField InputField;
    private int currentAttempt = 0;
    private void Awake()
    {
        NumText.text = $"�� {NumberManager.s_inst.minRandom} �� {NumberManager.s_inst.maxRandom}";
        NumberManager.s_inst.GenerateRandomNumber();
    }
    public void GuessNumber(int PlayerNum)
    {
        try
        {
            if (PlayerNum == NumberManager.s_inst.randomNumber)
            {
                MainText.text = "�� �������!";
                InputField.interactable = false;
                DataManager.s_inst.Money += NumberManager.s_inst.reward;
                StartCoroutine(WaitFor(4));
            }
            else
            {
                if (PlayerNum < NumberManager.s_inst.randomNumber)
                    MainText.text = "����� ������";
                else MainText.text = "����� ������";
                currentAttempt++;
                AttemptsText.text = $"�������: {NumberManager.s_inst.numOfAttempts - currentAttempt}";
            }
            if (currentAttempt >= NumberManager.s_inst.numOfAttempts)
            {
                MainText.text = "�� ���������!";
                InputField.interactable = false;
                DataManager.s_inst.Money -= NumberManager.s_inst.loss;
                StartCoroutine(WaitFor(4));
            }
        }
        catch (System.FormatException)
        {
            MainText.text = "�� ���������� �����";
        }
    }
    private IEnumerator WaitFor(int time)
    {
        yield return new WaitForSeconds(time);
        SceneButtons.MainMenuBtn();
    }
}
