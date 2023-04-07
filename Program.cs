using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Week3Assessment
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Display();
            
        }
        public static void Display()
        {
            Console.WriteLine("1. Add Sports: ");
            Console.WriteLine("2. Add ScoreBoard and Display: ");
            int CaseNumber = int.Parse(Console.ReadLine());
            switch (CaseNumber)
            {
                case 1:
                    Console.WriteLine("enter the sportsid to be added!");
                    int SportsID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter the sports name");
                    string name = Console.ReadLine();
                    string CONN_STRING = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= CollegeTournamentDetails;Integrated Security=True;Encrypt=False;";
                    SqlConnection con = new SqlConnection(CONN_STRING);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = $"insert into SportDetails values({SportsID},'{name}')" +
                                      $"select * from SportDetails";
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("SportsID    SportsName");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}      {reader.GetString(1)}");
                    }
                    reader.Close();
                    con.Close();

                    break;
                case 2:
                    Console.WriteLine("View ScoreBoard");
                    Console.WriteLine("==============================");
                    string CONN_STRING1 = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= CollegeTournamentDetails;Integrated Security=True;Encrypt=False;";
                    SqlConnection con1 = new SqlConnection(CONN_STRING1);
                    con1.Open();
                    SqlCommand cmd1 = con1.CreateCommand();
                    cmd1.CommandText =$"select * from ScoreBoardDetails;";
                    Console.WriteLine("ID || SportsName                                 score||TeamHead");
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                       
                        Console.WriteLine($"{reader1.GetInt32(0)}||{reader1.GetString(1)}{reader1.GetInt32(2)}|| {reader1.GetString(3)}");
                    }
                    reader1.Close();
                    con1.Close();
                    break;
                case 3:
                    string CONN_STRING2 = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= CollegeTournamentDetails;Integrated Security=True;Encrypt=False;";
                    SqlConnection con2 = new SqlConnection(CONN_STRING2);
                    con2.Open();
                    SqlCommand cmd2 = con2.CreateCommand();
                    cmd2.CommandText = $"select * from SportDetails";
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    Console.WriteLine("SportsID    SportsName");
                    while (reader2.Read())
                    {
                        Console.WriteLine($"{reader2.GetInt32(0)}      {reader2.GetString(1)}");
                    }
                    reader2.Close();
                    int sportsID = int.Parse(Console.ReadLine());
                    string TournamentName = Console.ReadLine();
                    SqlCommand cmd3 = new SqlCommand("TournamentUpdateDetails", con2);
                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd3.Parameters.Add("@SportsID", SqlDbType.Int).Value = sportsID;
                    cmd3.Parameters.Add("@tournamentTitle", SqlDbType.Text).Value = TournamentName;
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    while (reader3.Read())
                    {
                        Console.WriteLine($"{reader3.GetInt32(0)}      {reader3.GetString(1)}       {reader3.GetString(2)}");
                    }
                    reader3.Close();
                    Console.WriteLine("Tournament Table Updated");
                    con2.Close();

                    break;
                case 4:
                    string CONN_STRING3 = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= CollegeTournamentDetails;Integrated Security=True;Encrypt=False;";
                    SqlConnection con3 = new SqlConnection(CONN_STRING3);
                    con3.Open();
                    SqlCommand cmd5 = con3.CreateCommand();
                    cmd5.CommandText = $"select * from TournamentDetails";
                    SqlDataReader reader4 = cmd5.ExecuteReader();
                    while (reader4.Read())
                    {
                        Console.WriteLine($"{reader4.GetInt32(0)}      {reader4.GetString(1)}       {reader4.GetString(2)}");
                    }
                    reader4.Close();
                    con3.Close();
                    break;




            }
        }
    }
}