using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RunCommand : MonoBehaviour
{
    private Vector3 oldPosition;
    private Queue<string> commandsQueue = new Queue<string>();
    public GameObject PlayerField;
    public GameObject C;
    public Text CommandText;

    public void OnClick()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        GetAllChildObjects();

        GameObject whileObject = GameObject.FindGameObjectWithTag("while");
        GameObject[] ChildObjects = new GameObject[whileObject.transform.childCount];

        for (int i = 0; i < whileObject.transform.childCount; i++)
        {
            ChildObjects[i] = whileObject.transform.GetChild(i).gameObject;
        }
        string[] commandsOnWhile = new string[ChildObjects.Length];
        Array.Sort(ChildObjects, (a, b) => (int)b.transform.position.y - (int)a.transform.position.y);

        for (int i = 0; i < ChildObjects.Length; i++)
        {
            commandsOnWhile[i] = ChildObjects[i].name;
        }

        for (; commandsQueue.Count != 0;)
        {
            string command = commandsQueue.Dequeue();
            CommandText.text = command;
            switch (command)
            {
                case "right":
                    C.GetComponent<UnityChanAttempt>().RightRun();
                    break;
                case "left":
                    C.GetComponent<UnityChanAttempt>().LeftRun();
                    break;
                case "jump":
                    C.GetComponent<UnityChanAttempt>().Jump();
                    break;
                case "down":
                    C.transform.Translate(0, -2, 0);
                    break;
                case "rightRun":
                    C.GetComponent<UnityChanAttempt>().Runx();
                    break;
                case "leftRun":
                    C.GetComponent<UnityChanAttempt>().Runy();
                    break;
                case "if":
                    C.GetComponent<UnityChanAttempt>().ActivateOnCollisionStay();
                    yield return null;
                    C.GetComponent<UnityChanAttempt>().DeactivateOnCollisionStay();
                    break;
                case "while":
                    while(true)
                    {
                        oldPosition = C.transform.position;
                        foreach (string commandOnWhile in commandsOnWhile)
                        {
                            switch (commandOnWhile)
                            {
                                case "right":
                                    C.GetComponent<UnityChanAttempt>().RightRun();
                                    break;
                                case "left":
                                    C.GetComponent<UnityChanAttempt>().LeftRun();
                                    break;
                                case "jump":
                                    C.GetComponent<UnityChanAttempt>().Jump();
                                    break;
                                case "down":
                                    C.transform.Translate(0, -2, 0);
                                    break;
                                case "rightRun":
                                    C.GetComponent<UnityChanAttempt>().Runx();
                                    break;
                                case "leftRun":
                                    C.GetComponent<UnityChanAttempt>().Runy();
                                    break;
                                case "if":
                                    C.GetComponent<UnityChanAttempt>().ActivateOnCollisionStayOnWhile();
                                    break;
                                default:
                                    break;
                            }
                            yield return new WaitForSeconds(1.0f);
                        }
                        
                        yield return new WaitForSeconds(1.0f);
                        Vector3 currentPosition = C.transform.position;
                        if (oldPosition == currentPosition)
                        {
                            C.GetComponent<UnityChanAttempt>().DeactivateOnCollisionStayOnWhile();
                            break;
                        }
                        currentPosition = oldPosition;
                    }
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(2.0f);
        }
    }

    public void GetAllChildObjects()
    {
        GameObject[] ChildObjects = new GameObject[PlayerField.transform.childCount];

        for (int i = 0; i < PlayerField.transform.childCount; i++)
        {
            ChildObjects[i] = PlayerField.transform.GetChild(i).gameObject;
        }

        Array.Sort(ChildObjects, (a, b) => (int)b.transform.position.y - (int)a.transform.position.y);

        for (int i = 0; i < ChildObjects.Length; i++)
        {
            commandsQueue.Enqueue(ChildObjects[i].name);
        }
        commandsQueue.Enqueue("lastCommand");
    }
}
