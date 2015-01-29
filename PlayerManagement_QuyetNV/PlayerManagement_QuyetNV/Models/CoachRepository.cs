using CoachManagement_QuyetNV.Models;
using PlayerManagement_QuyetNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CoachManagement_QuyetNV.Models
{
    public class CoachRepository : ICoachRepository
    {
        private List<Coach> allCoachs;
        private XDocument coachData;

        public CoachRepository()
        {
            allCoachs = new List<Coach>();

            coachData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
            var coachs = from coach in coachData.Descendants("coach")
                          select new Coach(coach.Element("id").Value, coach.Element("name").Value, (DateTime) coach.Element("dateOfBirth"),
                              coach.Element("imageLink").Value, coach.Element("position").Value, coach.Element("clubName").Value);

            allCoachs.AddRange(coachs.ToList<Coach>());
        }


        //Return list of coachs
        public IEnumerable<Coach> GetCoachs()
        {
            return allCoachs;
        }

        public Coach GetCoachByID(String id)
        {
            return allCoachs.Find(item => item.id.Equals(id));
        }

        //Add new coach

        public void InsertCoach(Coach coach)
        {
            
            coachData.Descendants("coachs").FirstOrDefault().Add(new XElement("coach", new XElement("id", coach.id), 
                new XElement("name", coach.name), new XElement("dateOfBirth", coach.dateOfBirth), new XElement ("imageLink", coach.imageLink),
                new XElement("position", coach.position), new XElement("clubName",coach.clubName)));

            coachData.Save(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
        }

        // Delete Record
        public void DeleteCoach(String id)
        {
            coachData.Descendants("coachs").Elements("coach").Where(i => i.Element("id").Value.Equals(id)).Remove();

            coachData.Save(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
        }

        // Edit Record
        public void EditCoach(Coach coach)
        {
            
            XElement node = coachData.Descendants("coachs").Elements("coach").Where(i => i.Element("id").Value.Equals(coach.id)).FirstOrDefault();

            node.SetElementValue("id", coach.id);
            node.SetElementValue("name", coach.name);
            node.SetElementValue("dateOfBirth", coach.dateOfBirth);
            node.SetElementValue("imageLink", coach.imageLink);
            node.SetElementValue("position", coach.position);
            node.SetElementValue("clubName", coach.clubName);

            coachData.Save(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
        }
    }
}