using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleLog : MonoBehaviour
{
    public TextMeshProUGUI battleLog;

    private int counter = 0;
    private Queue<string> logs = new Queue<string>();

    public void AddLine()
    {
        counter++;

        if (logs.Count > 4)
        {
            logs.Enqueue($"Added line {counter}");
            logs.Dequeue();
        }
        else
        {
            logs.Enqueue($"Added line {counter}");
        }

        battleLog.text = string.Join("\n", Reverse(logs));
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
