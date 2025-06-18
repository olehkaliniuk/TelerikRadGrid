<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlNutzerdaten.ascx.cs" Inherits="UserControls.UserControlNutzerdaten" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



  
    <div class="grid-container">

        <!-- RadGrid für Nutzer -->
        <telerik:RadGrid ID="RadGrid1" runat="server"
            AutoGenerateColumns="False"
            Skin="Bootstrap"
            AllowPaging="True"
            AllowSorting="True"
            AllowFilteringByColumn="True"

            OnNeedDataSource="RadGrid1_NeedDataSource"
            OnInsertCommand="RadGrid1_InsertCommand"
            OnUpdateCommand="RadGrid1_UpdateCommand"
            OnDeleteCommand="RadGrid1_DeleteCommand"
            DataKeyNames="NutzerID">

            <MasterTableView CommandItemDisplay="Top"
                             DataKeyNames="Id"
                             EditMode="EditForms">

                <Columns>

                    <telerik:GridBoundColumn  DataField="Vorname"
                                              HeaderText="Vorname"
                                              UniqueName="Vorname" />

                    <telerik:GridBoundColumn  DataField="Nachname"
                                              HeaderText="Nachname"
                                              UniqueName="Nachname" />

                    <telerik:GridBoundColumn  DataField="Anrede"
                                              HeaderText="Anrede"
                                              UniqueName="Anrede" />

                    <telerik:GridCheckBoxColumn DataField="IstAktiv"
                                                HeaderText="Aktiv?"
                                                UniqueName="IstAktiv"
                                                DataType="System.Boolean" />

                    <telerik:GridDateTimeColumn DataField="UrlaubVon"
                                                HeaderText="Urlaub von"
                                                UniqueName="UrlaubVon"
                                                DataFormatString="{0:yyyy-MM-dd}"
                                                PickerType="DatePicker" />

                    <telerik:GridDateTimeColumn DataField="UrlaubBis"
                                                HeaderText="Urlaub bis"
                                                UniqueName="UrlaubBis"
                                                DataFormatString="{0:yyyy-MM-dd}"
                                                PickerType="DatePicker" />

                    <telerik:GridBoundColumn  DataField="RolleDesNutzers"
                                              HeaderText="Rolle"
                                              UniqueName="RolleDesNutzers" />
                    <telerik:GridEditCommandColumn />
                    <telerik:GridButtonColumn CommandName="Delete"
                                              Text="Delete"
                                              ConfirmText="Wirklich löschen?" />

                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>

