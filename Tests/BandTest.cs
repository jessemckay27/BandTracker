using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
  public class BandTest: IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=desktop-ddsnb9e;Initial Catalog=band_tracker_test;Integrated Security=SSPI";
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_test;Integrated Security=SSPI";
    }

    [Fact]
    public void GetAll_BandsEmptyAtFirst_0()
    {
      int getBand = Band.GetAll().Count;
      Assert.Equal(0, getBand);
    }

    [Fact]
    public void Equal_EquivalentBandObjectsAreEqual_true()
    {
      Band testBand1 = new Band("Grateful Dead");
      Band testBand2 = new Band("Grateful Dead");

      Assert.Equal(testBand1, testBand2);
    }

    [Fact]
    public void Save_NewBandSavesToDatabase_BandList()
    {
      Band testBand = new Band("Grateful Dead");
      testBand.Save();

      List<Band> savedBands = Band.GetAll();
      List<Band>  testBands = new List<Band>{testBand};

      Assert.Equal(savedBands, testBands);
    }

    [Fact]
    public void Save_AssignsIdToNewBandObject_BandId()
    {
      Band savedBand = new Band("Grateful Dead");
      savedBand.Save();

      Band testBand = Band.GetAll()[0];

      int savedId = savedBand.GetId();
      int testId = testBand.GetId();

      Assert.Equal(savedId, testId);
    }

    [Fact]
    public void AddVenue_AddsVenueToBand_VenueList()
    {
      Band newBand = new Band("Grateful Dead");
      newBand.Save();

      Venue testVenue1 = new Venue("The Filmore");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Cornell University");
      testVenue2.Save();

      newBand.AddVenue(testVenue1);
      newBand.AddVenue(testVenue2);

      List<Venue> savedVenues = newBand.GetVenues();
      List<Venue> testVenues = new List<Venue>{testVenue1, testVenue2};

      Assert.Equal(savedVenues, testVenues);
    }

    [Fact]
    public void GetVenues_ReturnAllVenuesFromBand_VenueList()
    {
      Band newBand = new Band("Grateful Dead");
      newBand.Save();

      Venue testVenue1 = new Venue("The Filmore");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Cornell University");
      testVenue2.Save();

      newBand.AddVenue(testVenue1);
      newBand.AddVenue(testVenue2);

      List<Venue> savedVenue = newBand.GetVenues();
      List<Venue> testVenue = new List<Venue>{testVenue1, testVenue2};

      Assert.Equal(savedVenue, testVenue);
    }

    [Fact]
    public void Find_FindBandInDatabase_BandId()
    {
      Band newBand = new Band("Grateful Dead");
      newBand.Save();

      Band foundBand = Band.Find(newBand.GetId());

      Assert.Equal(newBand, foundBand);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
