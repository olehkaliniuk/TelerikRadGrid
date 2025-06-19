using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;


namespace UserControls
{
    public partial class UserControlAdressverwaltung : System.Web.UI.UserControl
    {
        protected void RadGridAdresse_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var repo = new RepAdresse();
            RadGridAdresse.DataSource = repo.GetAllAdress();
        }

        protected void RadGridAdresse_InsertCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = (GridEditableItem)e.Item;
            var repo = new RepAdresse();

            Adresse a = new Adresse
            {
                Bezeichnung = (editableItem["Bezeichnung"].Controls[0] as TextBox).Text,
                Strasse = (editableItem["Strasse"].Controls[0] as TextBox).Text,
                Hausnummer = (editableItem["Hausnummer"].Controls[0] as TextBox).Text,
                Postleitzahl = (editableItem["Postleitzahl"].Controls[0] as TextBox).Text,
                Land = (editableItem["Land"].Controls[0] as TextBox).Text,
                Iban = (editableItem["Iban"].Controls[0] as TextBox).Text,
                Bic = (editableItem["Bic"].Controls[0] as TextBox).Text,
                IstInsolvent = (editableItem["IstInsolvent"].Controls[0] as CheckBox).Checked,
                IstAktiv = (editableItem["IstAktiv"].Controls[0] as CheckBox).Checked,
                AnsprechpartnerName = (editableItem["AnsprechpartnerName"].Controls[0] as TextBox).Text,
                AnsprechpartnerTelefonnummer = (editableItem["AnsprechpartnerTelefonnummer"].Controls[0] as TextBox).Text,
                RechnungsadresseAnschrift = (editableItem["RechnungsadresseAnschrift"].Controls[0] as TextBox).Text,
                RechnungsadresseStraﬂe = (editableItem["RechnungsadresseStraﬂe"].Controls[0] as TextBox).Text,
                RechnungsadressePostleitzahl = (editableItem["RechnungsadressePostleitzahl"].Controls[0] as TextBox).Text,
                RechnungsadresseLand = (editableItem["RechnungsadresseLand"].Controls[0] as TextBox).Text,
                Stadt = (editableItem["Stadt"].Controls[0] as TextBox).Text,
            };

            repo.AdresseHinzufuegen(a);
        }


        protected void RadGridAdresse_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = (GridEditableItem)e.Item;
            var repo = new RepAdresse();

            Adresse a = new Adresse
            {
                Id = Convert.ToInt32(editableItem.GetDataKeyValue("Id")),
                Bezeichnung = (editableItem["Bezeichnung"].Controls[0] as TextBox).Text,
                Strasse = (editableItem["Strasse"].Controls[0] as TextBox).Text,
                Hausnummer = (editableItem["Hausnummer"].Controls[0] as TextBox).Text,
                Postleitzahl = (editableItem["Postleitzahl"].Controls[0] as TextBox).Text,
                Land = (editableItem["Land"].Controls[0] as TextBox).Text,
                Iban = (editableItem["Iban"].Controls[0] as TextBox).Text,
                Bic = (editableItem["Bic"].Controls[0] as TextBox).Text,
                IstInsolvent = (editableItem["IstInsolvent"].Controls[0] as CheckBox).Checked,
                IstAktiv = (editableItem["IstAktiv"].Controls[0] as CheckBox).Checked,
                AnsprechpartnerName = (editableItem["AnsprechpartnerName"].Controls[0] as TextBox).Text,
                AnsprechpartnerTelefonnummer = (editableItem["AnsprechpartnerTelefonnummer"].Controls[0] as TextBox).Text,
                RechnungsadresseAnschrift = (editableItem["RechnungsadresseAnschrift"].Controls[0] as TextBox).Text,
                RechnungsadresseStraﬂe = (editableItem["RechnungsadresseStraﬂe"].Controls[0] as TextBox).Text,
                RechnungsadressePostleitzahl = (editableItem["RechnungsadressePostleitzahl"].Controls[0] as TextBox).Text,
                RechnungsadresseLand = (editableItem["RechnungsadresseLand"].Controls[0] as TextBox).Text,
                Stadt = (editableItem["Stadt"].Controls[0] as TextBox).Text,
            };

            repo.AdresseAktualisieren(a);
        }



        protected void RadGridAdresse_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            var item = (GridDataItem)e.Item;
            int id = Convert.ToInt32(item.GetDataKeyValue("Id"));
            var repo = new RepAdresse();
            repo.AdresseLoeschen(id);
        }









    }


}