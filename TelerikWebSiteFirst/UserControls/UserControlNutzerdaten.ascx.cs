using System;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;


namespace UserControls
{
    public partial class UserControlNutzerdaten : System.Web.UI.UserControl
    {
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var repo = new Repository();
            RadGrid1.DataSource = repo.GetAlleNutzer();
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            var edit = (GridEditableItem)e.Item;
            var nutzer = new Nutzer
            {
                Vorname = (edit["Vorname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Nachname = (edit["Nachname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Anrede = (edit["Anrede"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                IstAktiv = (edit["IstAktiv"].Controls[0] as System.Web.UI.WebControls.CheckBox).Checked,
                UrlaubVon = GetDate(edit, "UrlaubVon"),
                UrlaubBis = GetDate(edit, "UrlaubBis"),
                RolleDesNutzers = (edit["RolleDesNutzers"].Controls[0] as System.Web.UI.WebControls.TextBox).Text
            };

            new Repository().NutzerHinzufuegen(nutzer);
        }

        protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            var edit = (GridEditableItem)e.Item;
            int id = (int)edit.GetDataKeyValue("Id");

            var nutzer = new Nutzer
            {
                Id = id,
                Vorname = (edit["Vorname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Nachname = (edit["Nachname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Anrede = (edit["Anrede"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                IstAktiv = (edit["IstAktiv"].Controls[0] as System.Web.UI.WebControls.CheckBox).Checked,
                UrlaubVon = GetDate(edit, "UrlaubVon"),
                UrlaubBis = GetDate(edit, "UrlaubBis"),
                RolleDesNutzers = (edit["RolleDesNutzers"].Controls[0] as System.Web.UI.WebControls.TextBox).Text
            };

            new Repository().NutzerAktualisieren(nutzer);
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            int id = (int)((GridDataItem)e.Item).GetDataKeyValue("Id");
            new Repository().NutzerLoeschen(id);
        }


        //get DateTime from RadDatePicker
        private DateTime? GetDate(GridEditableItem item, string column)
        {
            var picker = item[column].Controls[0] as Telerik.Web.UI.RadDatePicker;
            return picker != null && picker.SelectedDate.HasValue
                   ? (DateTime?)picker.SelectedDate.Value
                   : null;
        }
    }
}
