using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace KinderGarten.Model
{
    public class KinderGartenDbAccess
    {
        private readonly KinderGartenDbEntities _db;

        public KinderGartenDbAccess(KinderGartenDbEntities db)
        {
            _db = db;
        }

       
        public List<KinderGarten.Model.Entity.Groups> GetGroup()
        {
           var group = _db.Groups.ToList();
            group.Insert(0, new KinderGarten.Model.Entity.Groups {ID = -1, Name = "Показать всё" });
            return group;


        }
        public List<User> GetUsers()
        {
            return _db.User.ToList();
        }

        public void AddUser(User user)
        {
            _db.User.Add(user);
            _db.SaveChanges();
        }

        public List<Teachers> GetTeachers()
        {
            return _db.Teachers.ToList();
        }
        public void RemoveSchedule(int ID)
        {
            var schedule = _db.Schedule.Find(ID);
            if (schedule != null)
            {
                _db.Schedule.Remove(schedule);
                _db.SaveChanges();
            }
        }
        public void UpdateChildren(Children children)
        {
            var dbCh = _db.Children.Find(children.ID);
            if (dbCh !=null)
            {
                dbCh.Name= children.Name;
                dbCh.Surname = children.Surname;
                dbCh.DateOfBirth =children.DateOfBirth;
                dbCh.GroupID = children.GroupID;
                dbCh.FatherId = children.FatherId;
                dbCh.MomId = children.MomId;
                _db.SaveChanges();
            }
        }
        public void RemoveChildren(int ID)
        {
            var children = _db.Children.Find(ID);
            if (children != null)
            {
                _db.Children.Remove(children);
                _db.SaveChanges();
            }
        }
        public void RemoveParents(int ID)
        {
            var parents = _db.Parents.Find(ID);
            if (parents != null)
            {
                _db.Parents.Remove(parents);
                _db.SaveChanges();
            }
        }
        public void RemoveGroup(int ID)
        {
            var schedule = _db.Groups.Find(ID);
            if (schedule != null)
            {
                _db.Groups.Remove(schedule);
                _db.SaveChanges();
            }
        }
        public void RemoveTeacher(int ID)
        {
            var schedule = _db.Teachers.Find(ID);
            if (schedule != null)
            {
                _db.Teachers.Remove(schedule);
                _db.SaveChanges();
            }
        }

        public void UpdateGroup(KinderGarten.Model.Entity.Groups groups)
        {
            var dbGroups = _db.Groups.Find(groups.ID);
            if (dbGroups != null)
            {
                dbGroups.Name = groups.Name;
                dbGroups.Teachers1Id = groups.Teachers1Id;
                dbGroups.AgeFrom= groups.AgeFrom;
                dbGroups.AgeTo = groups.AgeTo;
                dbGroups.MaxCapacity= groups.MaxCapacity;
                _db.SaveChanges();
            }
        }
        public bool IsScheduleConflicting(Schedule schedule)
        {
            // Находим все расписание, которые имеют конфликтующие временные интервалы с переданным расписанием schedule (учителя и группы).
            var conflictingSchedules = _db.Schedule.Where(s => s.GroupID == schedule.GroupID || s.TeacherID == schedule.TeacherID)
                                                    .Where(s => s.ID != schedule.ID) // не учитываем текущее расписание
                                                    .Where(s => (s.Date == schedule.Date && schedule.StartTime >= s.StartTime && schedule.StartTime < s.EndTime) ||
                                                                (s.Date == schedule.Date && schedule.EndTime > s.StartTime && schedule.EndTime <= s.EndTime) ||
                                                                (s.Date == schedule.Date && schedule.StartTime < s.StartTime && schedule.EndTime > s.EndTime))
                                                    .ToList();

            // Если нашлись конфликтующие расписания, значит это время уже занято, и возвращаем true.
            if (conflictingSchedules.Count > 0)
            {
                return true;
            }

            return false;
        }
        public void UpdateSchedule(Schedule schedule)
        {
            var dbSchedule = _db.Schedule.Find(schedule.ID); // получаем объект Schedule из базы данных по ID
            if (dbSchedule != null)
            {
                dbSchedule.Date = schedule.Date; // изменяем свойства объекта из параметра метода

                dbSchedule.StartTime = schedule.StartTime;
                dbSchedule.EndTime = schedule.StartTime + TimeSpan.FromMinutes(40); // вычисляем время окончания
                dbSchedule.Activity = schedule.Activity;
                dbSchedule.TeacherID = schedule.TeacherID;
                dbSchedule.GroupID = schedule.GroupID;
                _db.SaveChanges(); // сохраняем изменения в базе данных
            }
        }


        public void AddTeacher(Teachers teacher)
        {
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
        }

        public void RemoveTeacher(Teachers teacher)
        {
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
        }
        public List<Parents> GetParents()
        {
            return _db.Parents.ToList();
        }

        public void AddParent(Parents parent)
        {
            _db.Parents.Add(parent);
            _db.SaveChanges();
        }
        public void AddChildren(Children children)
        {
            _db.Children.Add(children);
            _db.SaveChanges();
        }
        public List<Children> GetChildren()
        {
            return _db.Children.ToList();
        }

        public void AddChild(Children child)
        {
            _db.Children.Add(child);
            _db.SaveChanges();
        }

        public List<Schedule> GetSchedules()
        {
            return _db.Schedule.ToList();
        }

        public void UpdateParents(Parents _parents)
        {
            var dbParents = _db.Parents.Find(_parents.ID);
            if (dbParents != null)
            {
                dbParents.Name = _parents.Name;
                dbParents.Surname = _parents.Surname;
                dbParents.Address = _parents.Address;
                dbParents.NumberPhone = _parents.NumberPhone;
                dbParents.NumberPasport = _parents.NumberPasport;
                dbParents.SerialPasport = _parents.SerialPasport;
                _db.SaveChanges();
            }
        }
        public void UpdateTeachers(Teachers _teachers)
        {
            var dbTeachers = _db.Teachers.Find(_teachers.ID);
            if (dbTeachers != null)
            {
                dbTeachers.Name = _teachers.Name;
                dbTeachers.Surname = _teachers.Surname;
                dbTeachers.Address = _teachers.Address;
                dbTeachers.HireDate = _teachers.HireDate;
                dbTeachers.NumberPasport= _teachers.NumberPasport;
                dbTeachers.SerialPasport= _teachers.SerialPasport;
                dbTeachers.NumberPhone= _teachers.NumberPhone;
                dbTeachers.Salary= _teachers.Salary;
                _db.SaveChanges();
            }
        }
        public void UpdateTeacherPhoto(Teachers teacher)
        {
            var dbTeacher = _db.Teachers.Find(teacher.ID);
            if (dbTeacher != null)
            {
                string photoPath = dbTeacher.PhotoTeachers;
                dbTeacher.PhotoTeachers = System.IO.Path.GetFileName(teacher.PhotoTeachers);
                _db.SaveChanges();
            }
        }

        public int AddTeacherWithPhoto(Teachers teacher, string photoPath)
        {
            var dbTeacher = _db.Teachers.Add(teacher);
            _db.SaveChanges();

            string newFilename = System.IO.Path.GetFileNameWithoutExtension(photoPath);
            string extension = System.IO.Path.GetExtension(photoPath);
            string savePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", newFilename + extension);
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"));
            System.IO.File.Copy(photoPath, savePath);
            dbTeacher.PhotoTeachers = System.IO.Path.GetFileName(photoPath);
            _db.SaveChanges();

            return dbTeacher.ID;
        }
        public void AddTeachers(Teachers teachers, string photoPath)
        {
            var db = new KinderGartenDbEntities();
            teachers.PhotoTeachers = System.IO.Path.GetFileName(photoPath);
            db.Teachers.Add(teachers);
            db.SaveChanges();
        }
        public void UpdateTeacherPhoto(string photoPath)
        {
            try
            {
                Teachers teacher = _db.Teachers.First();
                teacher.PhotoTeachers = photoPath;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var v in ex.EntityValidationErrors)
                {
                    foreach (var e in v.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {e.PropertyName} Error: {e.ErrorMessage}");
                    }
                }
            }
        
    }
        public void AddSchedule(Schedule schedule)
        {
            _db.Schedule.Add(schedule);
            _db.SaveChanges();
        }

        public List<KinderGarten.Model.Entity.Groups> GetGroups()
        {
            return _db.Groups.ToList();
        }

        public void AddGroup(KinderGarten.Model.Entity.Groups group)
        {
            _db.Groups.Add(group);
            _db.SaveChanges();
        }
 
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
