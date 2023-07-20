using KinderGarten.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderGarten.Model
{
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ScheduleItem
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Activity { get; set; }
        public int GroupID { get; set; }
        public string Teacher { get; set; }

        public virtual Groups Group { get; set; }
    }

    public class KinderGartenDBEntities : DbContext
    {
        public DbSet<ScheduleItem> ScheduleItems { get; set; }
        public DbSet<Model.Entity.Groups> Groups { get; set; }
    }
}
