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
      DBConfiguration.ConnectionString = "Data Source=desktop-ddsnb9e;Initial Catalog=band_tracker_test;Integrated Security=SSPI";
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_test;Integrated Security=SSPI";
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
      List<Band>  testBands = new List<Band>{testBand};

      Assert.Equal(savedBands, testBands);
    }

    [Fact]
    public void Save_AssignsNewIdToObject_Id()
    {
      Venue savedVenue = new Venue("The Filmore");
      savedVenue.Save();

      Venue testVenue = Venue.GetAll()[0];

      int savedId = savedVenue.GetId();
      int testId = testVenue.GetId();

      Assert.Equal(savedId, testId);
    }





    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
