using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MessageBoxControl : System.Web.UI.UserControl
{
    #region Properties
    private bool showCloseButton;
    public bool ShowCloseButton
    {
        get { return showCloseButton; }
        set { showCloseButton = value; }
    }
    #endregion

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ShowCloseButton)
            CloseButton.Attributes.Add("onclick", "document.getElementById('" +
                MessageBox.ClientID + "').style.display = 'none'");
        
    }
    #endregion

    #region Enum
    public enum MessageType
    {
        Error = 1,
        Info = 2,
        Success = 3,
        Warning = 4,
        Validation = 5
    }
    #endregion

    #region Show methods
    public void Show(MessageType messageType, string message)
    {
        CloseButton.Visible = showCloseButton;
        litMessage.Text = message;

        MessageBox.CssClass = messageType.ToString().ToLower();
        this.Visible = true;
    }
    public void ShowError(string message)
    {
        Show(MessageType.Error, message);
    }
    public void ShowInfo(string message)
    {
        Show(MessageType.Info, message);
    }
    public void ShowSuccess(string message)
    {
        Show(MessageType.Success, message);
    }
    public void ShowWarning(string message)
    {
        Show(MessageType.Warning, message);
    }
    public void ShowValidateError(string message)
    {
        Show(MessageType.Validation, message);
    }

    #endregion
}
