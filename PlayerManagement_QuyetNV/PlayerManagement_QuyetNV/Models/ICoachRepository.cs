using PlayerManagement_QuyetNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachManagement_QuyetNV.Models
{
    public interface ICoachRepository
    {
        IEnumerable<Coach> GetCoachs();
        Coach GetCoachByID(String id);
        void InsertCoach(Coach coach);
        void DeleteCoach(String id);
        void EditCoach(Coach coach);
    }
}
