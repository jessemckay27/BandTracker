using Nancy;
using System.Collections.Generic;
using System;
using BandTracker.Objects;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/bands"] = _ => {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };

      Get["/bands/new"] = _ => {
        return View["bands_form.cshtml"];
      };

      Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Get["/bands/{id}"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        return View["band.cshtml", selectedBand];
      };




      Get["/venues"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };

      Get["/venues/new"] = _ => {
        return View["venues_form.cshtml"];
      };

      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["/venues/{id}"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        return View["venue.cshtml", selectedVenue];
      };





      Post["/bands/delete"] = _ => {
        Band.DeleteAll();
        return View["success.cshtml"];
      };

      Post["/venues/delete"] = _ => {
        Venue.DeleteAll();
        return View["success.cshtml"];
      };


    }
  }
}
