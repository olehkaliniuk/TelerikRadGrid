using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class AddressRepository
{
    private readonly string _connectionString;

    public AddressRepository()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["TelerikWebSiteFirstConnectionString"].ConnectionString;
    }

    public DataTable GetAllAddresses()
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Adresse";
            var adapter = new SqlDataAdapter(query, conn);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }

    public void DeleteAddress(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new SqlCommand("DELETE FROM Adresse WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void SaveAddress(Dictionary<string, string> dynamicFields, string firma, string bezeichnung, string land, string ansprechpartner, int? id = null)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                if (id.HasValue)
                {
                    cmd.CommandText = @"UPDATE Adresse SET
                        Region=@Region, Strasse=@Strasse, Hausnummer=@Hausnummer, PLZ=@PLZ, Ort=@Ort,
                        Gebaeude=@Gebaeude, Firma=@Firma, Bezeichnung=@Bezeichnung,
                        Land=@Land, Ansprechpartner=@Ansprechpartner
                        WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id.Value);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Adresse
                        (Region, Strasse, Hausnummer, PLZ, Ort, Gebaeude,
                         Firma, Bezeichnung, Land, Ansprechpartner)
                         VALUES
                        (@Region, @Strasse, @Hausnummer, @PLZ, @Ort, @Gebaeude,
                         @Firma, @Bezeichnung, @Land, @Ansprechpartner)";
                }

                cmd.Parameters.AddWithValue("@Region", dynamicFields.ContainsKey("Region") ? dynamicFields["Region"] : "");
                cmd.Parameters.AddWithValue("@Strasse", dynamicFields.ContainsKey("Strasse") ? dynamicFields["Strasse"] : "");
                cmd.Parameters.AddWithValue("@Hausnummer", dynamicFields.ContainsKey("Hausnummer") ? dynamicFields["Hausnummer"] : "");
                cmd.Parameters.AddWithValue("@PLZ", dynamicFields.ContainsKey("PLZ") ? dynamicFields["PLZ"] : "");
                cmd.Parameters.AddWithValue("@Ort", dynamicFields.ContainsKey("Ort") ? dynamicFields["Ort"] : "");
                cmd.Parameters.AddWithValue("@Gebaeude", dynamicFields.ContainsKey("Gebaeude") ? dynamicFields["Gebaeude"] : "");


                cmd.Parameters.AddWithValue("@Firma", firma);
                cmd.Parameters.AddWithValue("@Bezeichnung", bezeichnung);
                cmd.Parameters.AddWithValue("@Land", land);
                cmd.Parameters.AddWithValue("@Ansprechpartner", ansprechpartner);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public DataRow GetAddressById(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var cmd = new SqlCommand("SELECT * FROM Adresse WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
