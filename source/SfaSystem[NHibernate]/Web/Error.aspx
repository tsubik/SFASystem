<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SFASystem Web Administration</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="master-wrapper-page">
        <div class="master-wrapper-content">
            <div class="header">
                <div class="logo">
                </div>
                <div class="version">
                    <asp:Label runat="server" ID="lblHeader" />
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="content">
                <div class="cph">
                    <div class="errorDiv">
                        <div class="title">
                            <asp:Label ID="infoMsg" runat="server" />
                        </div>
                        <div class="content">
                            <img class="image" alt="Wystąpił błąd" src="<%=ResolveUrl("~/App_Themes/Administration/images/error_logo.png") %>" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
