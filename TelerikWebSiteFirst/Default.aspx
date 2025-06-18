<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>


<!-- Zwei Komponenten 1)Nutzer 2)Adresse-->
<%@ Register TagPrefix="uc1" TagName="UserControlNutzerdaten" Src="~/UserControls/UserControlNutzerdaten.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControlAdressverwaltung" Src="~/UserControls/UserControlAdressverwaltung.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style/main.css" rel="stylesheet" type="text/css" />
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <script type="text/javascript">

    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <div>

          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1">
            <Tabs>
                <telerik:RadTab Text="Nutzerdaten" PageViewID="UserTab" />
                <telerik:RadTab Text="Adressverwaltung" PageViewID="AddressTab" />
            </Tabs>
        </telerik:RadTabStrip>

  
         <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
       <!--Nutzer!-->
            <telerik:RadPageView ID="UserTab" runat="server">
                <uc1:UserControlNutzerdaten ID="UserControlNutzerdaten1" runat="server" />
            </telerik:RadPageView>

       <!--Adresse!-->
            <telerik:RadPageView ID="AddressTab" runat="server">
                <uc2:UserControlAdressverwaltung ID="UserControlAdressverwaltung1" runat="server" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>


    </div>
    </form>
</body>
</html>
