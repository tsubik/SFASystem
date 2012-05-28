using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;

public partial class MasterPage : System.Web.UI.MasterPage
{
   // public event EventHandler UpdatePage;

    public void UpdatePanel()
    {
        //updatePanelMain.Update();
    }




    public void ShowMessage(Message message)
    {
        if (message != null)
        {
            switch (message.MessageType)
            {
                case MessageType.Success:
                    messageBox.ShowSuccess(message.Text);
                    break;
                case MessageType.Error:
                    messageBox.ShowError(message.Text);
                    break;
                case MessageType.Info:
                    messageBox.ShowInfo(message.Text);
                    break;
                case MessageType.ValidateError:
                    messageBox.ShowValidateError(message.Text);
                    break;
                case MessageType.Warning:
                    messageBox.ShowWarning(message.Text);
                    break;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Message message = StateItems.Message;
        if (message != null)
        {
            switch (message.MessageType)
            {
                case MessageType.Success:
                    messageBox.ShowSuccess(message.Text);
                    break;
                case MessageType.Error:
                    messageBox.ShowError(message.Text);
                    break;
                case MessageType.Info:
                    messageBox.ShowInfo(message.Text);
                    break;
                case MessageType.ValidateError:
                    messageBox.ShowValidateError(message.Text);
                    break;
                case MessageType.Warning:
                    messageBox.ShowWarning(message.Text);
                    break;
            }
        }
        StateItems.Message = null;
        loginStatus.LogoutText = Context.User.Identity.Name + " [wyloguj]";
        linkOrderMode.Visible = StateItems.IsInOrderMode;
        if (!Page.IsPostBack)
        {
            
        }
    }
    protected void mnuAdmin_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        e.Item.ImageUrl = ((SiteMapNode)e.Item.DataItem)["IconUrl"];
    }
}
