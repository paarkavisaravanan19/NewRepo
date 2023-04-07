using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;

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
            Console.WriteLine("3. Add Tournament Names ");
            Console.WriteLine("4. Remove sports");
            Console.WriteLine("5. Tornament Deletion ");
            Console.WriteLine("6. Edit scoreboard ");
            Console.WriteLine("7. Remove player ");
            Console.WriteLine("****************************************");
            string CONN_STRING = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= CollegeTournamentDetails;Integrated Security=True;Encrypt=False;";
            SqlConnection con = new SqlConnection(CONN_STRING);
            string option = "";
            do
            {
                Console.WriteLine("enter a number to proceed");
                int CaseNumber = int.Parse(Console.ReadLine());
                switch (CaseNumber)
                {
                    case 1:
                        Console.WriteLine("***********Adding Sports Funtionality : ***************");
                        Console.WriteLine("enter the sports ID to be added!");
                        int SportsID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the sports name");
                        string name = Console.ReadLine();
                        con.Open();
                        SqlCommand cmdCase1 = new SqlCommand("InsertionSportAndTournament", con);
                        cmdCase1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase1.Parameters.Add("@SportsID", SqlDbType.Int).Value = SportsID;
                        cmdCase1.Parameters.Add("@SportsName", SqlDbType.Text).Value = name;
                        SqlDataReader readerCase1 = cmdCase1.ExecuteReader();
                        Console.WriteLine("=================Table of sports details content==========");
                        while (readerCase1.Read())
                        {
                            Console.WriteLine($"{readerCase1.GetInt32(0)}      {readerCase1.GetString(1)}");
                        }
                        readerCase1.Close();
                        Console.WriteLine($"{SportsID} and {name} has been added");
                        con.Close();
                        break;
                    case 2:
                        con.Open();
                        Console.WriteLine("============Adding ScoreBoard and Display:========= ");
                        Console.WriteLine("View ScoreBoard");
                        Console.WriteLine("==============================");
                        SqlCommand cmdCase2 = con.CreateCommand();
                        cmdCase2.CommandText = $"select * from ScoreBoardDetails;";
                        Console.WriteLine("*****************table content of ScoreboardDetails****************");
                        SqlDataReader readerCase2 = cmdCase2.ExecuteReader();
                        while (readerCase2.Read())
                        {

                            Console.WriteLine($"{readerCase2.GetInt32(0)}||{readerCase2.GetString(1)}{readerCase2.GetInt32(2)}|| {readerCase2.GetString(3)}");
                        }
                        readerCase2.Close();
                        con.Close();
                        break;
                    case 3:
                        con.Open();
                        Console.WriteLine("=================Adding Tournament Names================");
                        SqlCommand cmdCase3 = con.CreateCommand();
                        cmdCase3.CommandText = $"select * from SportDetails";
                        SqlDataReader readerCase3 = cmdCase3.ExecuteReader();
                        Console.WriteLine("**************SportsDetails Content**************");
                        while (readerCase3.Read())
                        {
                            Console.WriteLine($"{readerCase3.GetInt32(0)}      {readerCase3.GetString(1)}");
                        }
                        readerCase3.Close();
                        Console.WriteLine("Enter a sports ID to add Tournament ");
                        int sportsID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a sportsName to add Tournament ");
                        string Sname = Console.ReadLine();
                        Console.WriteLine("Enter a TournamentName to be addded");
                        string TournamentName = Console.ReadLine();
                        SqlCommand cmdCase3Update = new SqlCommand("TournamentUpdateDetails", con);
                        cmdCase3Update.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase3Update.Parameters.Add("@SportsID", SqlDbType.Int).Value = sportsID;
                        cmdCase3Update.Parameters.Add("@tournamentTitle", SqlDbType.Text).Value = TournamentName;
                        SqlDataReader readerCase3Update = cmdCase3Update.ExecuteReader();
                        Console.WriteLine("*************Tournament Details Content************");
                        while (readerCase3Update.Read())
                        {
                            Console.WriteLine($"{readerCase3Update.GetInt32(0)}      {readerCase3Update.GetString(1)}       {readerCase3Update.GetString(2)}");
                        }
                        readerCase3Update.Close();
                        Console.WriteLine("Tournament Table Updated");
                        SqlCommand cmdCase3UpdateScoreBoard = new SqlCommand("InsertionScoreAndTournament", con);
                        cmdCase3UpdateScoreBoard.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase3UpdateScoreBoard.Parameters.Add("@SportsID", SqlDbType.Int).Value = sportsID;
                        cmdCase3UpdateScoreBoard.Parameters.Add("@SportsName", SqlDbType.Text).Value = Sname;
                        cmdCase3UpdateScoreBoard.Parameters.Add("@TournamentName", SqlDbType.Text).Value = TournamentName;
                        con.Close();
                        break;
                    case 4:
                        con.Open();
                        Console.WriteLine("==================Remove sports================");
                        Console.WriteLine("enter id to delete the sports");
                        int sportsIDCase4 = int.Parse(Console.ReadLine());
                        SqlCommand cmdCase4 = new SqlCommand("SportsDeletionDetails", con);
                        cmdCase4.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase4.Parameters.Add("@SportsID", SqlDbType.Int).Value = sportsIDCase4;
                        SqlDataReader readerCase4 = cmdCase4.ExecuteReader();
                        while (readerCase4.Read())
                        {
                            Console.WriteLine($"{readerCase4.GetInt32(0)}      {readerCase4.GetString(1)}   {readerCase4.GetString(2)}");
                        }
                        readerCase4.Close();
                        con.Close();
                        Console.WriteLine("It has been Deleted");
                        break;
                    case 5:
                        con.Open();
                        Console.WriteLine("==================Tornament Deletion===================== ");
                        SqlCommand cmdCase5 = con.CreateCommand();
                        cmdCase5.CommandText = $"select * from ScoreBoardDetails";
                        SqlDataReader readerCase5 = cmdCase5.ExecuteReader();

                        while (readerCase5.Read())
                        {
                            Console.WriteLine($"{readerCase5.GetInt32(0)} {readerCase5.GetString(1)} {readerCase5.GetInt32(2)} {readerCase5.GetString(7)} ");
                        }
                        readerCase5.Close();
                        Console.WriteLine("enter id to be deleted:");
                        int sportsIDCase5 = int.Parse(Console.ReadLine());
                        SqlCommand cmdCase5Delete = new SqlCommand("TournamentDeletion", con);
                        cmdCase5Delete.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase5Delete.Parameters.Add("@SportsID", SqlDbType.Int).Value = sportsIDCase5;
                        SqlDataReader readerCase5Show = cmdCase5Delete.ExecuteReader();
                        Console.WriteLine("============================Tournamet Details Table==============================");
                        while (readerCase5Show.Read())
                        {
                            Console.WriteLine($"{readerCase5Show.GetInt32(0)}      {readerCase5Show.GetString(1)}   {readerCase5Show.GetString(2)}");
                        }
                        readerCase5Show.Close();
                        con.Close();
                        Console.WriteLine("It has been Deleted");
                        
                        break;
                    case 6:
                        con.Open();
                        Console.WriteLine("==============Edit scoreboard================== ");
                        Console.WriteLine("enter the sports id to edit the scoreboard: ");
                        int S_ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the score to be updated");
                        int U_score = int.Parse(Console.ReadLine());
                        SqlCommand cmdCase6 = new SqlCommand("UpdateScoreBoardDetails", con);
                        cmdCase6.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdCase6.Parameters.Add("@SportsID", SqlDbType.Int).Value = S_ID;
                        cmdCase6.Parameters.Add("@Score", SqlDbType.Int).Value = U_score;
                        Console.WriteLine("=========================Score Board Details============================");
                        SqlDataReader readerCase6 = cmdCase6.ExecuteReader();
                        while (readerCase6.Read())
                        {
                            Console.WriteLine($"{readerCase6.GetInt32(0)}      {readerCase6.GetString(1)}       {readerCase6.GetInt32(2)}");
                        }
                        readerCase6.Close();
                        con.Close();

                        break;
                    case 7:
                        con.Open();
                        Console.WriteLine("=============Remove player==============");
                        Console.WriteLine("enter the sports id for disqualifying the player");
                        int SportID = int.Parse(Console.ReadLine());
                        SqlCommand cmdCase7 = con.CreateCommand();
                        cmdCase7.CommandText = $"update ScoreBoardDetails set TeamPlayer1 = 'disqualified' where SportsID = {SportID}" +
                            $"select * from ScoreBoardDetails";
                        SqlDataReader reader = cmdCase7.ExecuteReader();
                        Console.WriteLine("==============================Score Board Details==============================");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(0)}      {reader.GetString(1)}      {reader.GetString(4)}");
                        }
                        reader.Close();
                        con.Close();
                        break;

                }
                Console.WriteLine("do you want to proceed ! yes or no");
                option = Console.ReadLine();
            } while (string.Equals("yes", option));

            if (string.Equals("no", option))
            {
                Console.WriteLine("ENDS!");
                Console.WriteLine("====================================");
            }

        }
    }
}