using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Adresse
{
    public int Id { get; set; }
    public string Bezeichnung { get; set; }
    public string Strasse { get; set; }
    public string Hausnummer { get; set; }
    public string Postleitzahl { get; set; }
    public string Land { get; set; }
    public string Iban { get; set; }
    public string Bic { get; set; }
    public bool IstInsolvent { get; set; }
    public bool IstAktiv { get; set; }
    public string AnsprechpartnerName { get; set; }
    public string AnsprechpartnerTelefonnummer { get; set; }
    public string RechnungsadresseAnschrift { get; set; }
    public string RechnungsadresseStraße { get; set; }
    public string RechnungsadressePostleitzahl { get; set; }
    public string RechnungsadresseLand { get; set; }
    public string Stadt {  get; set; }
}