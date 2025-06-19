using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


public class RepNutzer
{
    private readonly string _cs = ConfigurationManager.ConnectionStrings["TelerikWebSiteFirstConnectionString"].ConnectionString;

    //Nutzer
    public List<Nutzer> GetAlleNutzer()
    {
        var list = new List<Nutzer>();

        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand("SELECT * FROM Nutzer", conn))
        {
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    list.Add(new Nutzer
                    {
                        Id = (int)rdr["Id"],
                        Vorname = rdr["Vorname"].ToString(),
                        Nachname = rdr["Nachname"].ToString(),
                        Anrede = rdr["Anrede"].ToString(),
                        IstAktiv = (bool)rdr["IstAktiv"],
                        UrlaubVon = rdr["UrlaubVon"] as DateTime?,
                        UrlaubBis = rdr["UrlaubBis"] as DateTime?,
                        RolleDesNutzers = rdr["RolleDesNutzers"].ToString()
                    });
                }
            }
        }
        return list;
    }

    public void NutzerHinzufuegen(Nutzer n)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand(
            @"INSERT INTO Nutzer
            (Vorname, Nachname, Anrede, IstAktiv, UrlaubVon, UrlaubBis, RolleDesNutzers)
            VALUES (@Vorname, @Nachname, @Anrede, @IstAktiv, @UrlaubVon, @UrlaubBis, @RolleDesNutzers)", conn))
        {
            cmd.Parameters.AddWithValue("@Vorname", n.Vorname);
            cmd.Parameters.AddWithValue("@Nachname", n.Nachname);
            cmd.Parameters.AddWithValue("@Anrede", n.Anrede);
            cmd.Parameters.AddWithValue("@IstAktiv", n.IstAktiv);
            cmd.Parameters.AddWithValue("@UrlaubVon", (object)n.UrlaubVon ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UrlaubBis", (object)n.UrlaubBis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RolleDesNutzers", n.RolleDesNutzers);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void NutzerAktualisieren(Nutzer n)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand(
            @"UPDATE Nutzer SET
                Vorname = @Vorname,
                Nachname = @Nachname,
                Anrede = @Anrede,
                IstAktiv = @IstAktiv,
                UrlaubVon = @UrlaubVon,
                UrlaubBis = @UrlaubBis,
                RolleDesNutzers = @RolleDesNutzers
              WHERE Id = @Id", conn))
        {
            cmd.Parameters.AddWithValue("@Id", n.Id);
            cmd.Parameters.AddWithValue("@Vorname", n.Vorname);
            cmd.Parameters.AddWithValue("@Nachname", n.Nachname);
            cmd.Parameters.AddWithValue("@Anrede", n.Anrede);
            cmd.Parameters.AddWithValue("@IstAktiv", n.IstAktiv);
            cmd.Parameters.AddWithValue("@UrlaubVon", (object)n.UrlaubVon ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UrlaubBis", (object)n.UrlaubBis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RolleDesNutzers", n.RolleDesNutzers);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void NutzerLoeschen(int id)
    {
        using (var conn = new SqlConnection(_cs))
        using (var cmd = new SqlCommand("DELETE FROM Nutzer WHERE Id = @Id", conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

}