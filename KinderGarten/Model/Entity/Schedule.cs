//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinderGarten.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Schedule
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan StartTime { get; set; }

        public string GroupName
        {
            get
            {
                using (var context = new KinderGartenDbEntities())
                {
                    var a = context.Groups.Where(x => x.ID == GroupID)?.FirstOrDefault();
                    return a.Name;
                }
            }
        }
        public string TeacherName
        {
            get
            {
                using (var context = new KinderGartenDbEntities())
                {
                    var a = context.Teachers.Where(x => x.ID == TeacherID)?.FirstOrDefault();
                    return a.Surname + " " + a.Name;
                }
            }
        }
        public System.TimeSpan EndTime { get; set; }
        public string Activity { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<int> TeacherID { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
