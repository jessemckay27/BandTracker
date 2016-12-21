using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
  public class VenueTest: IDisposable
  {
    public VenueTest()
    {
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI";
      DBConfiguration.ConnectionString = "Data Source=desktop-ddsnb9e;Initial Catalog=band_tracker_test;Integrated Security=SSPI";
    }

    [Fact]
    public void Test_VenuesEmptyAtFirst_0()
    {
      int result = Band.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Equal_EquivalentVenueObjectsAreEqual_true()
    {
      Band testVenue1 = new Band("The Filmore");
      Band testVenue2 = new Band("The Filmore");

      Assert.Equal(testVenue1, testVenue2);
    }

    [Fact]
    public void Save_NewVenueSavesToDatabase_ListOfVenues()
    {
      Band testBand = new Band("Grateful Dead");
      testBand.Save();

      List<Band> savedBands = Band.GetAll();
      List<Band> testBands = new List<Band>{testBand};

      Assert.Equal(savedBands, testBands);
    }

    [Fact]
    public void Save_AssignsIdToNewVenueObject_Id()
    {
      Venue savedVenue = new Venue("The Filmore");
      savedVenue.Save();

      Venue testVenue = Venue.GetAll()[0];

      int savedId = savedVenue.GetId();
      int testId = testVenue.GetId();

      Assert.Equal(savedId, testId);
    }

    [Fact]
    public void AddBand_AddsBandToVenue_BandList()
    {
      Venue newVenue = new Venue("The Filmore");
      newVenue.Save();

      Band testBand1 = new Band("Grateful Dead");
      testBand1.Save();

      Band testBand2 = new Band("Jerry Garcia Band");
      testBand2.Save();

      newVenue.AddBand(testBand1);
      newVenue.AddBand(testBand2);

      List<Band> savedBands = newVenue.GetBands();
      List<Band> testBands = new List<Band>{testBand1, testBand2};

      Assert.Equal(savedBands, testBands);
    }

    [Fact]
    public void GetBands_ReturnAllBandsFromVenue_BandList()
    {
      Venue newVenue = new Venue("The Filmore");
      newVenue.Save();

      Band testBand1 = new Band("Grateful Dead");
      testBand1.Save();

      Band testBand2 = new Band("Jerry Garcia Band");
      testBand2.Save();

      newVenue.AddBand(testBand1);
      newVenue.AddBand(testBand2);


      List<Band> savedBand = newVenue.GetBands();
      List<Band> testBand = new List<Band> {testBand1, testBand2};

      Assert.Equal(savedBand, testBand);
    }

    [Fact]
    public void Find_FindVenueInDatabase_VenueId()
    {
      Venue newVenue = new Venue("Cornell University");
      newVenue.Save();

      Venue foundVenue = Venue.Find(newVenue.GetId());

      Assert.Equal(newVenue, foundVenue);
    }

    [Fact]
    public void Test_UpdatesVenueInDatabase()
    {
      Venue newVenue = Venue("Jerry Garcia");
      newVenue.Save();
      newVenue.Update("Bob Weir");

      Venue testVenue = Venue("Bob Weir");

      Assert.Equal(newVenue, testVenue);
    }


    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
