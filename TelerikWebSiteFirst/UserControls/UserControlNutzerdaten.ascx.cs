using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;


namespace UserControls
{
    public partial class UserControlNutzerdaten : System.Web.UI.UserControl
    {

     

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var repo = new RepNutzer();
            RadGrid1.DataSource = repo.GetAlleNutzer();
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            var edit = (GridEditableItem)e.Item;


          
            var nutzer = new Nutzer
            {
                Vorname = (edit["Vorname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Nachname = (edit["Nachname"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
                Anrede = (edit["Anrede"].FindControl("ddlAnrede") as System.Web.UI.WebControls.DropDownList).SelectedValue,
                IstAktiv = (edit["IstAktiv"].Controls[0] as System.Web.UI.WebControls.CheckBox).Checked,
                UrlaubVon = GetDate(edit, "UrlaubVon"),
                UrlaubBis = GetDate(edit, "UrlaubBis"),
                RolleDesNutzers = (edit["RolleDesNutzers"].Controls[0] as System.Web.UI.WebControls.TextBox).Text,
            };

            var repo = new RepNutzer();
            

            if(repo.NutzerExistiert(nutzer.Vorname, nutzer.Nachname))
            {
                int idAlt = repo.HoleNutzerId(nutzer.Vorname, nutzer.Nachname);
                if (idAlt > 0) 
                {
                    repo.NutzerLoeschen(idAlt);
                }    

            }
            new RepNutzer().NutzerHinzufuegen(nutzer);
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
                Anrede = (edit["Anrede"].FindControl("ddlAnrede") as System.Web.UI.WebControls.DropDownList).SelectedValue,
                IstAktiv = (edit["IstAktiv"].Controls[0] as System.Web.UI.WebControls.CheckBox).Checked,
                UrlaubVon = GetDate(edit, "UrlaubVon"),
                UrlaubBis = GetDate(edit, "UrlaubBis"),
                RolleDesNutzers = (edit["RolleDesNutzers"].Controls[0] as System.Web.UI.WebControls.TextBox).Text
            };

            new RepNutzer().NutzerAktualisieren(nutzer);
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            int id = (int)((GridDataItem)e.Item).GetDataKeyValue("Id");
            new RepNutzer().NutzerLoeschen(id);
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
