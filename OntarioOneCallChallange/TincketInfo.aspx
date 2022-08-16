<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TincketInfo.aspx.cs" Inherits="OntarioOneCallChallange.TincketInfo" %>

<link href="TicketInfoDesign.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="header_container">
        <div class="logo">
           <img class="img" src="assets/images/OntarioOneCall_Image.png" />
        </div>
        <div class="description">
            <p class="header">Parent child part: <span>
                <asp:Label ID="lbl_ParentChild" runat="server" Text="Label"></asp:Label></span></p>

            <p class="sub_title">Current Selection: <span>
                <asp:Label ID="lbl_CurrentSelection" runat="server" Text="Label"></asp:Label></span></p>
        </div>
    </div>

    <form class="form" id="form1" runat="server">
        <div class="Container">
            <div class="">
                <asp:TreeView ID="TreeView1" runat="server" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" ShowCheckBoxes="Leaf"></asp:TreeView>
            </div>

        </div>
        <div class="btn_group">
            
            <div style="padding-left: 200px; padding-top: 0px">
                <asp:Button ID="btn_populateTree" runat="server" Text="Populate the Tree" Width="200px" Height="36px" OnClick="btn_populateTree_Click" /><br />

            </div>
            <div style="padding-left: 200px; padding-top: 20px">
                <asp:Button ID="btn_ExitApp" runat="server" Text="Exit Application" Width="200px" OnClick="btn_ExitApp_Click1" Height="36px" /><br />

            </div>
        </div>
        <div class="grid_view">
            <asp:GridView ID="GridView_Component" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>