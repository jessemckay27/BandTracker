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
      int result = Band.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Equal_EquivalentBandObjectsAreEqual_true()
    {
      Band testBand1 = new Band("Grateful Dead");
      Band testBand2 = new Band("Grateful Dead");

      Assert.Equal(testBand1, testBand2);
    }




    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
