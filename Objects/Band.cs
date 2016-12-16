using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
  public class Band
  {

    private string _name;
    private int _id;

    public Band(string Name, int Id = 0)
    {
      _name = Name;
      _id = Id;
    }

  }
}
