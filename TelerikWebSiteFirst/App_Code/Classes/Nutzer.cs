using System;
public class Nutzer
{
    public int Id { get; set; }           
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Anrede { get; set; }
    public bool IstAktiv { get; set; }
    public DateTime? UrlaubVon { get; set; }
    public DateTime? UrlaubBis { get; set; }
    public string RolleDesNutzers { get; set; }
}
