<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanstwaMiasta.aspx.cs" Inherits="Install_Rozne_PanstwaMiasta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="filePanstwa" runat="server" />
        <asp:Button ID="uploadPanstwa" runat="server" onclick="uploadPanstwa_Click" 
            Text="Upload Panstwa" /><br />
        <asp:Button ID="btnUsunMiasta" runat="server" Text="Usuń dublujące się miasta" 
            onclick="btnUsunMiasta_Click" />
        <asp:FileUpload ID="fileMiasta" runat="server" /><asp:Button ID="uploadMiasta" 
            runat="server" onclick="uploadMiasta_Click" Text="Upload Miasta" />
    </div>
    </form>
</body>
</html>
