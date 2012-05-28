using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Message
/// </summary>
[Serializable]
public class Message
{
    public MessageType MessageType { get; set; }
    public string Text { get; set; }

    public Message()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Message(MessageType type, string text)
    {
        this.MessageType = type;
        this.Text = text;
    }
}

public enum MessageType
{
    Error = 0,
    Success = 1,
    Warning = 2,
    ValidateError = 3,
    Info = 4
}
