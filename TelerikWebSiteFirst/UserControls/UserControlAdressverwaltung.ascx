<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlAdressverwaltung.ascx.cs" Inherits="UserControls.UserControlAdressverwaltung" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div>

        <!-- Adress List -->
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <telerik:RadGrid ID="RadGridAddresses"
                    runat="server"
                    AutoGenerateColumns="false"
                    Skin="Bootstrap"
                    AllowPaging="True"
                    OnNeedDataSource="RadGridAddresses_NeedDataSource"
                    OnItemCommand="RadGridAddresses_ItemCommand"

             
                    AllowFilteringByColumn="true"
                    EnableLinqExpressions="true"
                    FilterDelay="500"
                    ShowFilterMenu="false">
                    <MasterTableView 
                             DataKeyNames="Id"
                            >
                        <Columns>
                            <telerik:GridBoundColumn DataField="Land" HeaderText="Land" UniqueName="Land" />
                            <telerik:GridBoundColumn DataField="Region" HeaderText="Region" UniqueName="Region" />
                            <telerik:GridBoundColumn DataField="Ort" HeaderText="Ort" UniqueName="Ort" />
                            <telerik:GridBoundColumn DataField="Strasse" HeaderText="Straße" UniqueName="Strasse" />
                            <telerik:GridBoundColumn DataField="Hausnummer" HeaderText="Hausnummer" UniqueName="Hausnummer" />
                            <telerik:GridBoundColumn DataField="PLZ" HeaderText="PLZ" UniqueName="PLZ" />

                            <telerik:GridBoundColumn DataField="Gebaeude" HeaderText="Gebäude" UniqueName="Gebaeude" />
                            <telerik:GridBoundColumn DataField="Firma" HeaderText="Firma" UniqueName="Firma" />
                            <telerik:GridBoundColumn DataField="Bezeichnung" HeaderText="Bezeichnung" UniqueName="Bezeichnung" />
                            <telerik:GridBoundColumn DataField="Ansprechpartner" HeaderText="Ansprechpartner" UniqueName="Ansprechpartner" />

                            <telerik:GridButtonColumn CommandName="Delete" Text="Delete" ButtonType="PushButton" />
                            <telerik:GridButtonColumn CommandName="Update" Text="Update" ButtonType="PushButton" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr />

      

        <!-- Form  -->
      

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                  <!-- toggle form  -->
  <telerik:RadButton ID="btnToggleForm" runat="server" Text="Create new" OnClick="btnToggleForm_Click" />

                 <div id="formCont" runat="server" style="display:none"> 

                    <asp:Label ID="lblM"  runat="server" Text="Insert" Style="font-size: 24px; font-weight: bold;"></asp:Label>
                     <br />

                <!-- Land auswaählen -->
                <telerik:RadComboBox ID="ddlCountry"
                    runat="server"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                <br />

                <!-- .json here -->
                <asp:PlaceHolder ID="phDynamicFields" runat="server" />
                <asp:HiddenField ID="hfEditId" runat="server" />
                <br />

                <asp:TextBox ID="Firma" runat="server" Placeholder="Firma" /><br />
                <asp:TextBox ID="Bezeichnung" runat="server" Placeholder="Bezeichnung" /><br />
                <asp:TextBox ID="Ansprechpartner" runat="server" Placeholder="Ansprechpartner" /><br />

                <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                 </div>
            </ContentTemplate>
            

        </asp:UpdatePanel>

    

</div>

         