using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class BattleLog : MonoBehaviour
{
    public TextMeshProUGUI battleLog;

    private int points = 0;
    private Queue<string> logs = new Queue<string>();

    public void AddLine(string line, int points = 0)
    {
        this.points += points;

        if (logs.Count > 4)
        {
            logs.Enqueue(line);
            logs.Dequeue();
        }
        else
        {
            logs.Enqueue(line);
        }

        battleLog.text = string.Join("\n", Reverse(logs));
    }
    /// <summary>
    /// Resets internal points and returns reward for winning combat.
    /// </summary>
    /// <returns>An int representing candies won in combat.</returns>
    public int GetWinReward()
    {
        int pointsEarned = points;
        points = 0;

        return pointsEarned;
    }

    private Queue<string> Reverse(Queue<string> queue)
    {
        var stack = new Stack<string>();
        var newQueue = new Queue<string>();

        foreach (var item in queue)
        {
            stack.Push(item);
        }

        for (int i = stack.Count; i > 0; i--)
        {
            newQueue.Enqueue(stack.Pop());
        }

        return newQueue;
    }

}
