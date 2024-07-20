using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;
using UnityEngine.Rendering.PostProcessing;

public delegate void action();
public class Dialogue_System : MonoBehaviour
{
    public GameObject dialogWindow;
    public GameObject answers;
    public TMP_Text message;
    public GameObject answer;
    public TMP_Text name;

    Dictionary<string, action> actions = new Dictionary<string, action>();
    CDialogue dialogue = new CDialogue();
    public void loadDialog(Object xmlFile)
    {
        dialogue.Clear();
        actions.Clear();
        actions.Add("none", null);
        actions.Add("start race", null);
        actions.Add("shelter", null);
        actions.Add("open shop", null);
        actions.Add("add coins", null);
        actions.Add("dialogue end", dialogEnd);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.ToString());
        XmlNode messages = xmlDoc.SelectSingleNode("//messages");
        XmlNodeList messageNodes = xmlDoc.SelectNodes("//messages/message");

        foreach (XmlNode messageNode in messageNodes)
        {
            CMessage msg = new CMessage();
            msg.text = messageNode.ChildNodes[0].InnerText;
            msg.msgID = long.Parse(messageNode.Attributes["uid"].Value);
            msg.name = messageNode.Attributes["name"].Value;
            dialogue.loadMessage(msg);

            foreach (XmlNode answerNode in messageNode.ChildNodes[1].ChildNodes)
            {
                CAnswer answ = new CAnswer();
                answ.answID = long.Parse(answerNode.Attributes["auid"].Value);
                answ.msgID = long.Parse(answerNode.Attributes["muid"].Value);
                answ.action = answerNode.Attributes["action"].Value;
                answ.text = answerNode.InnerText;
                dialogue.loadAnswer(answ);
            }
        }
        showMessage(dialogue.getMessages()[0].msgID, "none");
        dialogWindow.SetActive(true);
    }
    public void showMessage(long uid, string act)
    {
        actions[act]?.Invoke();
        if (uid == -1) return;
        foreach (Transform child in answers.transform)
        {
            Destroy(child.gameObject);
        }
        message.text = dialogue.selectMessage(uid);
        name.text = dialogue.selectName(uid);
        foreach (CAnswer ans in dialogue.getAnswers())
        {
            TMP_Text answer_txt = answer.GetComponentInChildren<TMP_Text>();
            Image answer_img = answer.GetComponentInChildren<Image>();
            TMP_Text txt = Instantiate<TMP_Text>(answer_txt);
            Image img = Instantiate<Image>(answer_img);
            txt.text = ans.text;
            txt.GetComponent<Button>().onClick.AddListener(delegate { showMessage(ans.msgID, ans.action); });
            img.transform.SetParent(answers.transform);
            txt.transform.SetParent(img.transform);
        } 
    }

    public void dialogEnd()
    {
        dialogWindow.SetActive(false);
    }

    public void setAction(string name, action act)
    {
        actions[name] = act;
    }
}
