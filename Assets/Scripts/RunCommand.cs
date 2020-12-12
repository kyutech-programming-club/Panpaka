using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RunCommand : MonoBehaviour
{
    private Vector3 oldPosition;
    private Queue<GameObject> commandsQueue = new Queue<GameObject>();
    public Vector3 initPosition;
    public GameObject PlayerField;
    public GameObject C;
    public Text CommandText;

    public void OnClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
        CommandCount.Reset();
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        GetAllChildObjects();

        for (; commandsQueue.Count != 0;)
        {
            GameObject commandObj = commandsQueue.Dequeue();
            string command = commandObj.tag;
            CommandText.text = command;
            switch (command)
            {
                case "right":
                    C.GetComponent<UnityChanAttempt>().RightRun();
                    break;
                case "left":
                    C.GetComponent<UnityChanAttempt>().LeftRun();
                    break;
                case "up":
                    C.GetComponent<UnityChanAttempt>().Jump();
                    break;
                case "down":
                    C.transform.Translate(0, -2, 0);
                    break;
                case "rightRun":
                    {
                        float x = C.GetComponent<UnityChanAttempt>().GetRightInput();
                        for (int i = 0; i < Math.Floor(x); i++)
                        {
                            C.GetComponent<UnityChanAttempt>().RightRun();
                            yield return new WaitForSeconds(1.0f);
                        }
                    }
                    break;
                case "leftRun":
                    {
                        float x = C.GetComponent<UnityChanAttempt>().GetLeftInput();
                        for (int i = 0; i < Math.Floor(x); i++)
                        {
                            C.GetComponent<UnityChanAttempt>().LeftRun();
                            yield return new WaitForSeconds(1.0f);
                        }
                    }
                    break;
                case "if":
                    C.GetComponent<UnityChanAttempt>().ActivateOnCollisionStay();
                    yield return null;
                    C.GetComponent<UnityChanAttempt>().DeactivateOnCollisionStay();
                    break;
                case "while":
                    GameObject whileCommand = commandObj.transform.GetChild(1).gameObject;
                    GameObject[] ChildObjects = new GameObject[whileCommand.transform.childCount];

                    for (int i = 0; i < whileCommand.transform.childCount; i++)
                    {
                        ChildObjects[i] = whileCommand.transform.GetChild(i).gameObject;
                    }
                    string[] commandsOnWhile = new string[ChildObjects.Length];
                    Array.Sort(ChildObjects, (a, b) => (int)b.transform.position.y - (int)a.transform.position.y);

                    for (int i = 0; i < ChildObjects.Length; i++)
                    {
                        commandsOnWhile[i] = ChildObjects[i].tag;
                        CommandCount.Add();
                    }
                    while (true)
                    {
                        oldPosition = C.transform.position;
                        foreach (string commandOnWhile in commandsOnWhile)
                        {
                            CommandText.text = commandOnWhile + "(whileの中)";
                            switch (commandOnWhile)
                            {
                                case "right":
                                    C.GetComponent<UnityChanAttempt>().RightRun();
                                    break;
                                case "left":
                                    C.GetComponent<UnityChanAttempt>().LeftRun();
                                    break;
                                case "up":
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
        gameObject.GetComponent<Button>().interactable = true;
        C.transform.position = initPosition;
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
            CommandCount.Add();
            commandsQueue.Enqueue(ChildObjects[i]);
        }
        GameObject last = new GameObject("lastCommand");
        last.tag = "lastCommand";
        commandsQueue.Enqueue(last);
    }
}
