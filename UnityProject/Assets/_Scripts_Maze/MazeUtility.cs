using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeUtility : MonoBehaviour {

    public static void AnnounceState(Text textArea, string message)
    {
        textArea.text = message;
    }

    public static void AnnounceBranch(Text textArea, string currentState, GameObject[] branches, int branchCounter)
    {
        switch (currentState)
        {
            case "Place1":
                textArea.text = "Branch Toggle (E) \n" + branches[branchCounter].name;
                foreach (GameObject obj in branches)
                {
                    if (obj.name == branches[branchCounter].name)
                    {
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                }
                break;
            default:
                textArea.text = "No branch possible";
                break;
        }
    }

    public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    public static IEnumerator RotateOverSeconds(GameObject objectToMove, float rotation, float seconds, bool openHandleOutwards)
    {
        print("started routine");
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.localEulerAngles;
        Vector3 endPos = objectToMove.transform.localEulerAngles;

        if (openHandleOutwards)
        {
            endPos.y += rotation;
        }
        else
        {
            endPos.y -= rotation;
        }

        while (elapsedTime < seconds)
        {
            objectToMove.transform.localEulerAngles = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.localEulerAngles = endPos;
        print("finished routine");
    }
}
