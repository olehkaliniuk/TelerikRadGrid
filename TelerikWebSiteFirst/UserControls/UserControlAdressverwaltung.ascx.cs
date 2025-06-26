using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;


namespace UserControls
{
    public partial class UserControlAdressverwaltung : System.Web.UI.UserControl
    {
        private AddressRepository repo = new AddressRepository();
        private Dictionary<string, List<FieldDefinition>> countryFields;

        public class FieldDefinition
        {
            public string label { get; set; }
            public string id { get; set; }
        }

        public class Country
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            countryFields = Session["countryFields"] as Dictionary<string, List<FieldDefinition>>;
            if (countryFields != null && ddlCountry != null && !string.IsNullOrEmpty(ddlCountry.SelectedValue))
                BuildDynamicForm(ddlCountry.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Загрузка полей для форм
                string jsonPathFields = Server.MapPath("~/Countries.json");
                string jsonContentFields = File.ReadAllText(jsonPathFields);
                var serializer = new JavaScriptSerializer();
                countryFields = serializer.Deserialize<Dictionary<string, List<FieldDefinition>>>(jsonContentFields);
                Session["countryFields"] = countryFields;

                // Загрузка списка стран из отдельного JSON
                string jsonPathCountries = Server.MapPath("~/countriesList.json");
                string jsonContentCountries = File.ReadAllText(jsonPathCountries);
                var countries = serializer.Deserialize<List<Country>>(jsonContentCountries);

                ddlCountry.Items.Clear();
                foreach (Country c in countries)
                {
                    ddlCountry.Items.Add(new RadComboBoxItem(c.Name, c.Code));
                }
                if (ddlCountry.Items.Count > 0)
                    ddlCountry.SelectedIndex = 0;

                BuildDynamicForm(ddlCountry.SelectedValue);
            }
            else
            {
                countryFields = Session["countryFields"] as Dictionary<string, List<FieldDefinition>>;
                BuildDynamicForm(ddlCountry.SelectedValue);
            }
        }


   

        protected void ddlCountry_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BuildDynamicForm(e.Value);
        }

     

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //validate
            if (!ValidateForm())
                return;



            var data = new Dictionary<string, string>
        {
            { "Region", GetTextBoxValue("Region") },
            { "Strasse", GetTextBoxValue("Strasse") },
            { "Hausnummer", GetTextBoxValue("Hausnummer") },
            { "PLZ", GetTextBoxValue("PLZ") },
            { "Ort", GetTextBoxValue("Ort") },
            { "Gebaeude", GetTextBoxValue("Gebaeude") }
        };

            string firma = Firma.Text;
            string bezeichnung = Bezeichnung.Text;
            string land = ddlCountry.SelectedItem.Text;
            string ansprechpartner = Ansprechpartner.Text;

            int? id = string.IsNullOrEmpty(hfEditId.Value) ? null : (int?)System.Convert.ToInt32(hfEditId.Value);

            repo.SaveAddress(data, firma, bezeichnung, land, ansprechpartner, id);

            hfEditId.Value = "";
            RadGridAddresses.Rebind();
            UpdatePanelGrid.Update();


            CloseForm();
        }

        protected void RadGridAddresses_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridAddresses.DataSource = repo.GetAllAddresses();
        }

        protected void RadGridAddresses_ItemCommand(object sender, GridCommandEventArgs e)
        {
            lblM.Text = "Insert";
            if (e.CommandName == "Delete")
            {
                GridDataItem item = e.Item as GridDataItem;
                if (item != null)
                {
                    int id = System.Convert.ToInt32(item.GetDataKeyValue("Id"));
                    repo.DeleteAddress(id);
                    RadGridAddresses.Rebind();
                }
            }
            else if (e.CommandName == "Update")
            {
                btnToggleForm.Text = "Close";
                lblM.Text = "Update";
                GridDataItem item = e.Item as GridDataItem;
                if (item != null)
                {
                    int id = System.Convert.ToInt32(item.GetDataKeyValue("Id"));
                    LoadAddressToForm(id);
                }
            }
        }

        private void LoadAddressToForm(int id)
        {

           

            var row = repo.GetAddressById(id);
            if (row != null)
            {
                string land = row["Land"].ToString();
                foreach (RadComboBoxItem item in ddlCountry.Items)
                {
                    if (item.Text == land)
                    {
                        ddlCountry.SelectedValue = item.Value;
                        break;
                    }
                }
                BuildDynamicForm(ddlCountry.SelectedValue);

                SetTextBoxValue("Region", row["Region"].ToString());
                SetTextBoxValue("Ort", row["Ort"].ToString());
                SetTextBoxValue("Strasse", row["Strasse"].ToString());
                SetTextBoxValue("Hausnummer", row["Hausnummer"].ToString());
                SetTextBoxValue("PLZ", row["PLZ"].ToString());
                SetTextBoxValue("Gebaeude", row["Gebaeude"].ToString());

                Firma.Text = row["Firma"].ToString();
                Bezeichnung.Text = row["Bezeichnung"].ToString();
                Ansprechpartner.Text = row["Ansprechpartner"].ToString();

                hfEditId.Value = id.ToString();


                ShowForm();

      
            }
        }

  
        private string GetTextBoxValue(string id)
        {
            var tb = phDynamicFields.FindControl(id) as RadTextBox;
            return tb != null ? tb.Text : "";
        }

        private void SetTextBoxValue(string id, string value)
        {
            RadTextBox tb = phDynamicFields.FindControl(id) as RadTextBox;
            if (tb != null) tb.Text = value;
        }

        private void BuildDynamicForm(string countryCode)
        {
            phDynamicFields.Controls.Clear();

            if (countryFields != null)
            {
                List<FieldDefinition> fields;
                if (countryFields.TryGetValue(countryCode, out fields))
                {
                    foreach (var field in fields)
                        AddTextbox(field.label, field.id);
                }
            }
        }

        private void AddTextbox(string label, string id)
        {
            phDynamicFields.Controls.Add(new LiteralControl(string.Format("<label for='{0}'>{1}</label><br/>", id, label)));
            var tb = new RadTextBox { ID = id, Width = new Unit(300, UnitType.Pixel) };
            phDynamicFields.Controls.Add(tb);
            phDynamicFields.Controls.Add(new LiteralControl("<br /><br />"));
        }

        protected void btnToggleForm_Click(object sender, EventArgs e)
        {
            string currentDisplay = formCont.Style["display"];

            if (string.IsNullOrEmpty(currentDisplay) || currentDisplay == "none")
            {
                lblM.Text = "Insert";
                formCont.Style["display"] = "block";
                btnToggleForm.Text = "Close";
            }
            else
            {
                formCont.Style["display"] = "none";
                btnToggleForm.Text = "Create new";
                ClearForm(); 
            }

            UpdatePanel1.Update();
        }

        private void ShowForm()
        {
            formCont.Style["display"] = "block";
            UpdatePanel1.Update();
        }

        private void CloseForm()
        {
            formCont.Style["display"] = "none";
            UpdatePanel1.Update();
            ClearForm();
        }

        private void ClearForm()
        {
            if (phDynamicFields != null)
            {
                foreach (Control ctrl in phDynamicFields.Controls)
                {
                    RadTextBox rtb = ctrl as RadTextBox;
                    if (rtb != null)
                    {
                        rtb.Text = string.Empty;
                    }
                }
            }

        
            Firma.Text = string.Empty;
            Bezeichnung.Text = string.Empty;
            Ansprechpartner.Text = string.Empty;

   
            hfEditId.Value = string.Empty;

       
            ddlCountry.SelectedIndex = 0;
        }




        private bool ValidateForm()
        {
            // Проверка динамических полей
            foreach (Control ctrl in phDynamicFields.Controls)
            {
                RadTextBox tb = ctrl as RadTextBox;
                if (tb != null && string.IsNullOrWhiteSpace(tb.Text))
                {  
                    return false;
                }
            }

            // Проверка статичных полей
            if (string.IsNullOrWhiteSpace(Firma.Text) ||
                string.IsNullOrWhiteSpace(Bezeichnung.Text) ||
                string.IsNullOrWhiteSpace(Ansprechpartner.Text))
            {
                return false;
            }

            // Проверка выбора страны
            if (ddlCountry.SelectedItem == null || string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                return false;
            }

 
            UpdatePanel1.Update();

            return true;
        }

   






    }
}