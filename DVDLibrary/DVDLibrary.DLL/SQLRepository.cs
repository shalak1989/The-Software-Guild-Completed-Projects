using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data.SqlClient;
using DVDLibrary.DLL.Config;
using System.Data;

namespace DVDLibrary.DLL
{
    public class SQLRepository : IDVDRepository
    {
        

        public void Delete(int DVDId)
        {
            var dvd = new DVD();
            bool result = false;

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DeleteDVD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", DVDId);

                cmd.Connection = cn;
                cn.Open();

                // Execute the command
                int rowsDeletedCount = cmd.ExecuteNonQuery();
                if (rowsDeletedCount != 0)
                    result = true;

                if (result == true)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("FAILURE!");
                }
            }
        }

        public DVD Get(int DVDId)
        {
            var dvd = new DVD();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetDvdById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", DVDId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd = PopulateDVDFromDataReader(dr);
                    }
                        
                    PopulateActorsFromDataReader(dvd);
                    PopulateBorrowersFromDataReader(dvd);
                }

                return dvd;
            }
        }

        public List<DVD> GetAll()
        {           
                List<DVD> dvds = new List<DVD>();

                using (var cn = new SqlConnection(Settings.ConnectionString))
                {
                    var cmd = new SqlCommand();
                    cmd.CommandText = "GetAllDVD";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = cn;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dvds.Add(PopulateDVDFromDataReader(dr));
                        }
                    }
                    foreach (var dvd in dvds)
                    {
                        PopulateActorsFromDataReader(dvd);
                        PopulateBorrowersFromDataReader(dvd);
                    //need populate directors?
                    }                   

                return dvds;
            }
        }

        private DVD PopulateDVDFromDataReader(SqlDataReader dr)
        {
            DVD dvd = new DVD();

            dvd.DVDId = (int)dr["DVDId"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
            dvd.Studio = dr["Studio"].ToString();
            dvd.UserRating = (decimal)dr["UserRating"];
            dvd.UserNotes = dr["UserNotes"].ToString();

            return dvd;
        }

        private DVD PopulateActorsFromDataReader(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetDVDActor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);


                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Actors.Add(dr["FirstName"].ToString());
                        dvd.Actors.Add(dr["LastName"].ToString());
                    }
                }

                return dvd;
            }
        }

        private DVD PopulateBorrowersFromDataReader(DVD dvd)
        {
            Borrower borrower = new Borrower();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetDVDBorrower";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);


                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.BorrowerList.Add(PopulateBorrower(dr));
                    }
                }

                return dvd;
            }
        }

        private Borrower PopulateBorrower(SqlDataReader dr)
        {
            Borrower borrower = new Borrower();

            borrower.FirstName = dr["FirstName"].ToString();
            borrower.LastName = dr["LastName"].ToString();

            return borrower;
        }

        public void Add(DVD DVD)
        {
            //DVD dvd = new DVD();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddDVD";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);not needed because I am adding a new one? 
                                                                   //Auto count from identity in SQL?
                cmd.Parameters.Add("@DVDTitle", SqlDbType.VarChar).Value = DVD.Title;
                cmd.Parameters.Add("@DVDReleaseDate", SqlDbType.Date).Value = DVD.ReleaseDate;
                cmd.Parameters.Add("@DVDMPPARatingId", SqlDbType.NChar).Value = DVD.MPAARating;
                cmd.Parameters.Add("@DVDStudio", SqlDbType.VarChar).Value = DVD.Studio;
                cmd.Parameters.Add("@DVDUserRating", SqlDbType.Decimal).Value = DVD.UserRating;
                cmd.Parameters.Add("@DVDUserNotes", SqlDbType.VarChar).Value = (object)DVD.UserNotes ?? DBNull.Value;
                               
                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record inserted successfully");
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        //        // SQL command
        //        String sSQLCommand = "INSERT INTO Person (Age, FirstName,
        //                         Description, Updated)  " +
        //                     "VALUES( 55, 'Bob', 'Is a Penguin',
        //                         '2001/12/25 20:30:15' );";
        //// Create the command object
        //ADOCommand cmdAdder = new ADOCommand(
        //    sSQLCommand,
        //    DB_CONN_STRING);
        //        cmdAdder.ActiveConnection.Open();
        //// Execute the SQL command
        //int nNoAdded = cmdAdder.ExecuteNonQuery();
        //        System.Console.WriteLine( "\nRow(s) Added = " + nNoAdded + "\n" );













    }
}
