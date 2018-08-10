using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectManager : MonoBehaviour {
    public Stack<IEnumerator> stack = new Stack<IEnumerator>();

    private void Start()
    {
        stack.Clear();
        StartCoroutine(Effecter());
    }

    IEnumerator Effecter()
    {
        while (true)
        {
            if (stack.Count > 0)
            {
                yield return StartCoroutine(stack.Pop());
            }
            else
            {
                yield return null;
            }
            
        }
    }
}
