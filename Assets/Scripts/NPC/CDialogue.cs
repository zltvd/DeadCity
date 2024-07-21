using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CAnswer
{
    public long answID = -1;
    public string text = "";
    public long msgID = -1;
    public string action = "";
}
public class CMessage
{
    public long msgID = -1;
    public string text = "";
    public string name = "";
    public List<CAnswer> answers = new List<CAnswer>();
}
public class CDialogue
{
    List<CMessage> messages = new List<CMessage>();
    long UID = 0;
    CMessage selectedMessage = null;
    CAnswer selectedAnswer = null;

    long getUID()
    {
        UID++;
        return UID;
    }
    CMessage findMsg(long msgID)
    {
        foreach (CMessage m in messages)
        {
            if (m.msgID == msgID)
                return m;
        }
        return null;
    }
    CAnswer findAnsw(long answID)
    {
        foreach (CAnswer a in selectedMessage.answers)
        {
            if (a.answID == answID)
                return a;
        }
        return null;
    }
    public long addMessage(CMessage msg, string name)
    {
        msg.msgID = getUID();
        msg.name = name;
        messages.Add(msg);
        selectedMessage = msg;
        return msg.msgID;
    }
    public long addAnswer(CAnswer answ, string action)
    {
        answ.answID = getUID();
        answ.action = action;
        selectedMessage.answers.Add(answ);
        return answ.answID;
    }
    public void correctAnswer(long msgID)
    {
        selectedAnswer.msgID = msgID;

    }
    public string selectMessage(long msgID)
    {
        selectedMessage = findMsg(msgID);
        return selectedMessage.text;
    }
    public string selectName(long msgID)
    {
        selectedMessage = findMsg(msgID);
        return selectedMessage.name;
    }
    public string selectAnswer(long msgID, long answID)
    {
        selectMessage(msgID);
        selectedAnswer = findAnsw(answID);
        return selectedAnswer.text + " [action: " + selectedAnswer.action + "]";
    }
    public void remoweMessage(long msgID)
    {
        selectMessage(msgID);
        messages.Remove(selectedMessage);
        selectedMessage = null;
    }
    public void remoweAnswer(long msgID, long answID)
    {
        selectMessage(msgID);
        selectAnswer(msgID, answID);
        selectedMessage.answers.Remove(selectedAnswer);
        selectedAnswer = null;
    }
    public void updateMessage(string text)
    {
        selectedMessage.text = text;
    }
    public void updateAnswer(string text, string action)
    {
        selectedAnswer.text = text;
        selectedAnswer.action = action;
    }
    public List<CMessage> getMessages()
    {
        List<CMessage> m = messages;
        return m;
    }

    public List<CAnswer> getAnswers()
    {
        return selectedMessage.answers;
    }

    public long linkedID()
    {
        long n = selectedAnswer.msgID;
        return n;
    }
    public void Clear()
    {
        messages.Clear();
        UID = 0;
    }
    public void loadMessage(CMessage msg)
    {
        messages.Add(msg);
        selectedMessage = msg;
    }
    public void loadAnswer(CAnswer answ)
    {
        selectedMessage.answers.Add(answ);
    }
    public long getlastUID()
    {
        long number = UID;
        return number;
    }
    public void setlastUID(long uid)
    {
        UID = uid;
    }
}
