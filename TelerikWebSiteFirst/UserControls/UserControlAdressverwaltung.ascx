<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlAdressverwaltung.ascx.cs" Inherits="UserControls.UserControlAdressverwaltung" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="grid-container">
    <telerik:RadGrid ID="RadGridAdresse" runat="server"
        AutoGenerateColumns="False"
        Skin="Bootstrap"
        AllowPaging="True"
        AllowSorting="True"
        AllowFilteringByColumn="True"
        OnNeedDataSource="RadGridAdresse_NeedDataSource"
        OnInsertCommand="RadGridAdresse_InsertCommand"
        OnUpdateCommand="RadGridAdresse_UpdateCommand"
        OnDeleteCommand="RadGridAdresse_DeleteCommand"
        DataKeyNames="Id">

        <MasterTableView CommandItemDisplay="Top"
                         EditMode="EditForms"
                         DataKeyNames="Id">
            <Columns>
                <telerik:GridBoundColumn DataField="Bezeichnung"
                                         HeaderText="Bezeichnung"
                                         UniqueName="Bezeichnung" />
                <telerik:GridBoundColumn DataField="Strasse"
                                         HeaderText="Straße"
                                         UniqueName="Strasse" />
                <telerik:GridBoundColumn DataField="Hausnummer"
                                         HeaderText="Hausnummer"
                                         UniqueName="Hausnummer" />
                <telerik:GridBoundColumn DataField="Postleitzahl"
                                         HeaderText="Postleitzahl"
                                         UniqueName="Postleitzahl" />
                <telerik:GridBoundColumn DataField="Land"
                                         HeaderText="Land"
                                         UniqueName="Land" />
                <telerik:GridBoundColumn DataField="Stadt"
                                         HeaderText="Stadt"
                                         UniqueName="Stadt" />
                <telerik:GridBoundColumn DataField="Iban"
                                         HeaderText="IBAN"
                                         UniqueName="Iban" />
                <telerik:GridBoundColumn DataField="Bic"
                                         HeaderText="BIC"
                                         UniqueName="Bic" />
                <telerik:GridCheckBoxColumn DataField="IstInsolvent"
                                            HeaderText="Ist insolvent?"
                                            UniqueName="IstInsolvent"
                                            DataType="System.Boolean" />
                <telerik:GridCheckBoxColumn DataField="IstAktiv"
                                            HeaderText="Ist aktiv?"
                                            UniqueName="IstAktiv"
                                            DataType="System.Boolean" />
                <telerik:GridBoundColumn DataField="AnsprechpartnerName"
                                         HeaderText="Ansprechpartner Name"
                                         UniqueName="AnsprechpartnerName" />
                <telerik:GridBoundColumn DataField="AnsprechpartnerTelefonnummer"
                                         HeaderText="Ansprechpartner Telefonnummer"
                                         UniqueName="AnsprechpartnerTelefonnummer" />
                <telerik:GridBoundColumn DataField="RechnungsadresseAnschrift"
                                         HeaderText="Rechnungsanschrift"
                                         UniqueName="RechnungsadresseAnschrift" />
                <telerik:GridBoundColumn DataField="RechnungsadresseStraße"
                                         HeaderText="Rechnungsstraße"
                                         UniqueName="RechnungsadresseStraße" />
                <telerik:GridBoundColumn DataField="RechnungsadressePostleitzahl"
                                         HeaderText="Rechnungs-PLZ"
                                         UniqueName="RechnungsadressePostleitzahl" />
                <telerik:GridBoundColumn DataField="RechnungsadresseLand"
                                         HeaderText="Rechnungsland"
                                         UniqueName="RechnungsadresseLand" />

                <telerik:GridEditCommandColumn ButtonType="ImageButton" />
                <telerik:GridButtonColumn CommandName="Delete"
                                          Text="Löschen"
                                          ConfirmText="Wirklich löschen?" />
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
