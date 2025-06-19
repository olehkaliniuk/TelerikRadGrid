using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


public class RepAdresse
{
    private readonly string _cs = ConfigurationManager.ConnectionStrings["TelerikWebSiteFirstConnectionString"].ConnectionString;



    //Adresse

    public List<Adresse> GetAllAdress()
    {
        var list = new List<Adresse>();

        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand("SELECT * FROM Adresse", conn))
        {
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    list.Add(new Adresse
                    {
                        Id = (int)rdr["Id"],
                        Bezeichnung = rdr["Bezeichnung"].ToString(),
                        Strasse = rdr["Strasse"].ToString(),
                        Hausnummer = rdr["Hausnummer"].ToString(),
                        Postleitzahl = rdr["PLZ"].ToString(),
                        Land = rdr["Land"].ToString(),
                        Iban = rdr["IBAN"].ToString(),
                        Bic = rdr["BIC"].ToString(),
                        IstInsolvent = rdr["IstInsolvent"] != DBNull.Value && (bool)rdr["IstInsolvent"],
                        IstAktiv = rdr["IstAktiv"] != DBNull.Value && (bool)rdr["IstAktiv"],
                        AnsprechpartnerName = rdr["AnsprechpartnerName"].ToString(),
                        AnsprechpartnerTelefonnummer = rdr["AnsprechpartnerTel"].ToString(),
                        RechnungsadresseAnschrift = rdr["RechnungsAnschrift"].ToString(),
                        RechnungsadresseStraﬂe = rdr["RechnungsStrasse"].ToString(),
                        RechnungsadressePostleitzahl = rdr["RechnungsPLZ"].ToString(),
                        RechnungsadresseLand = rdr["RechnungsLand"].ToString(),
                        Stadt = rdr["Stadt"].ToString()
                    });
                }
            }
        }

        return list;
    }



    public void AdresseHinzufuegen(Adresse a)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand(@"INSERT INTO Adresse 
        (Bezeichnung, Strasse, Hausnummer, PLZ, Land, IBAN, BIC, IstInsolvent, IstAktiv,
         AnsprechpartnerName, AnsprechpartnerTel, RechnungsAnschrift, RechnungsStrasse,
         RechnungsPLZ, RechnungsLand, Stadt)
        VALUES
        (@Bezeichnung, @Strasse, @Hausnummer, @PLZ, @Land, @IBAN, @BIC, @IstInsolvent, @IstAktiv,
         @AnsprechpartnerName, @AnsprechpartnerTel, @RechnungsAnschrift, @RechnungsStrasse,
         @RechnungsPLZ, @RechnungsLand, @Stadt)", conn))
        {
            cmd.Parameters.AddWithValue("@Bezeichnung", a.Bezeichnung);
            cmd.Parameters.AddWithValue("@Strasse", a.Strasse);
            cmd.Parameters.AddWithValue("@Hausnummer", a.Hausnummer);
            cmd.Parameters.AddWithValue("@PLZ", a.Postleitzahl);
            cmd.Parameters.AddWithValue("@Land", a.Land);
            cmd.Parameters.AddWithValue("@IBAN", a.Iban);
            cmd.Parameters.AddWithValue("@BIC", a.Bic);
            cmd.Parameters.AddWithValue("@IstInsolvent", a.IstInsolvent);
            cmd.Parameters.AddWithValue("@IstAktiv", a.IstAktiv);
            cmd.Parameters.AddWithValue("@AnsprechpartnerName", a.AnsprechpartnerName);
            cmd.Parameters.AddWithValue("@AnsprechpartnerTel", a.AnsprechpartnerTelefonnummer);
            cmd.Parameters.AddWithValue("@RechnungsAnschrift", a.RechnungsadresseAnschrift);
            cmd.Parameters.AddWithValue("@RechnungsStrasse", a.RechnungsadresseStraﬂe);
            cmd.Parameters.AddWithValue("@RechnungsPLZ", a.RechnungsadressePostleitzahl);
            cmd.Parameters.AddWithValue("@RechnungsLand", a.RechnungsadresseLand);
            cmd.Parameters.AddWithValue("@Stadt", a.Stadt);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }


    public void AdresseAktualisieren(Adresse a)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand(@"UPDATE Adresse SET 
        Bezeichnung = @Bezeichnung, Strasse = @Strasse, Hausnummer = @Hausnummer, 
        PLZ = @PLZ, Land = @Land, IBAN = @IBAN, BIC = @BIC,
        IstInsolvent = @IstInsolvent, IstAktiv = @IstAktiv,
        AnsprechpartnerName = @AnsprechpartnerName, AnsprechpartnerTel = @AnsprechpartnerTel,
        RechnungsAnschrift = @RechnungsAnschrift, RechnungsStrasse = @RechnungsStrasse,
        RechnungsPLZ = @RechnungsPLZ, RechnungsLand = @RechnungsLand, Stadt = @Stadt
        WHERE Id = @Id", conn))
        {
            cmd.Parameters.AddWithValue("@Id", a.Id);
            cmd.Parameters.AddWithValue("@Bezeichnung", a.Bezeichnung);
            cmd.Parameters.AddWithValue("@Strasse", a.Strasse);
            cmd.Parameters.AddWithValue("@Hausnummer", a.Hausnummer);
            cmd.Parameters.AddWithValue("@PLZ", a.Postleitzahl);
            cmd.Parameters.AddWithValue("@Land", a.Land);
            cmd.Parameters.AddWithValue("@IBAN", a.Iban);
            cmd.Parameters.AddWithValue("@BIC", a.Bic);
            cmd.Parameters.AddWithValue("@IstInsolvent", a.IstInsolvent);
            cmd.Parameters.AddWithValue("@IstAktiv", a.IstAktiv);
            cmd.Parameters.AddWithValue("@AnsprechpartnerName", a.AnsprechpartnerName);
            cmd.Parameters.AddWithValue("@AnsprechpartnerTel", a.AnsprechpartnerTelefonnummer);
            cmd.Parameters.AddWithValue("@RechnungsAnschrift", a.RechnungsadresseAnschrift);
            cmd.Parameters.AddWithValue("@RechnungsStrasse", a.RechnungsadresseStraﬂe);
            cmd.Parameters.AddWithValue("@RechnungsPLZ", a.RechnungsadressePostleitzahl);
            cmd.Parameters.AddWithValue("@RechnungsLand", a.RechnungsadresseLand);
            cmd.Parameters.AddWithValue("@Stadt", a.Stadt);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }



    public void AdresseLoeschen(int id)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand("DELETE FROM Adresse WHERE Id = @Id", conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}