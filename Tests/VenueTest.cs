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

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
