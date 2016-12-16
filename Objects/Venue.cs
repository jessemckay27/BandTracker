using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BandTracker.Objects
{
  public class Venue
  {

    private string _location; //column 1
    private int _id;   //column 0

    public Venue(string Location, int Id = 0)
    {
      _location = Location;
      _id = Id;
    }

    public string GetLocation()
    {
      return _location;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetLocation(string Location)
    {
      _location = Location;
    }

    public void SetId(int Id)
    {
      _id = Id;
    }

    public override bool Equals(System.Object otherVenue)
    {
      if(!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool locationEquality = (this.GetLocation() == newVenue.GetLocation());
        bool idEquality = (this.GetId() == newVenue.GetId());
        return (locationEquality && idEquality);
      }
    }

    public override int GetHashCode()
    {
      return _location.GetHashCode();
    }

    public static List<Venue>  GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        string venueLocation = rdr.GetString(1);
        int venueId = rdr.GetInt32(0);
        Venue newVenue = new Venue(venueLocation, venueId);
        allVenues.Add(newVenue);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allVenues;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (location) OUTPUT INSERTED.id VALUES (@LocationName);", conn);

      SqlParameter locationParameter = new SqlParameter();
      locationParameter.ParameterName = "@LocationName";
      locationParameter.Value = this.GetLocation();

      cmd.Parameters.Add(locationParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
