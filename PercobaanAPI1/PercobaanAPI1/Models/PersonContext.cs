using Npgsql;
using System;
using PercobaanAPI1.Helpers;

namespace PercobaanAPI1.Models
{
    public class PersonContext
    {
        private string __constr;
        private string __ErrorMsg;
        public PersonContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Person> ListPerson()
        {
            List<Person> list1 = new List<Person>();
            string query = "SELECT id_person, nama, alamat, email FROM person;";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list1.Add(new Person()
                            {
                                id_person = Convert.ToInt32(reader["id_person"]),
                                nama = reader["nama"].ToString(),
                                alamat = reader["alamat"].ToString(),
                                email = reader["email"].ToString()
                            });
                        }
                    }
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
            return list1;
        }

        public void AddPerson(Person person)
        {
            string query = "INSERT INTO person (id_person, nama, alamat, email) VALUES (@id, @nama, @alamat, @email)";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("id", person.id_person);
                    cmd.Parameters.AddWithValue("nama", person.nama);
                    cmd.Parameters.AddWithValue("alamat", person.alamat);
                    cmd.Parameters.AddWithValue("email", person.email);
                    cmd.ExecuteNonQuery();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }

        }

        public void UpdatePerson(Person person)
        {
            string query = "UPDATE person SET nama = @nama, alamat = @alamat, email = @email WHERE id_person = @id";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("nama", person.nama);
                    cmd.Parameters.AddWithValue("alamat", person.alamat);
                    cmd.Parameters.AddWithValue("email", person.email);
                    cmd.Parameters.AddWithValue("id", person.id_person);
                    cmd.ExecuteNonQuery();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }

        }

        public void DeletePerson(int id_person)
        {
            string query = "DELETE FROM person WHERE id_person = @id";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using (NpgsqlCommand cmd = db.getNpgsqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("id", id_person);
                    cmd.ExecuteNonQuery();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }
    }
}
