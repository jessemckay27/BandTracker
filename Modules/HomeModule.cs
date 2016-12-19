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
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band selectedBand = Band.Find(parameters.id); //gets current band info
        List<Venue> bandVenues = selectedBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band", selectedBand);
        model.Add("bandVenues", bandVenues);
        model.Add("allVenues", allVenues);
        return View["band.cshtml", model];
      };
      Post["band/add_venue"] = _ => {
        Band newBand = Band.Find(Request.Form["band-id"]);
        Venue newVenue = Venue.Find(Request.Form["venue-id"]);
        newBand.AddVenue(newVenue);
        return View["success.cshtml"];
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
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue selectedVenue = Venue.Find(parameters.id);
        List<Band> venueBands = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", selectedVenue);
        model.Add("venueBands", venueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };
      Post["venue/add_band"] = _ => {
        Venue newVenue = Venue.Find(Request.Form["venue-id"]);
        Band newBand = Band.Find(Request.Form["band-id"]);
        newVenue.AddBand(newBand);
        return View["success.cshtml"];
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
