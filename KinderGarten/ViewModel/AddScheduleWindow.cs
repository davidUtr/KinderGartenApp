using KinderGarten.Model.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KinderGarten.ViewModel
{
    public class AddScheduleWindow : BaseViewModel
    {
        private DateTime _date;
        private TimeSpan _start, _end;
        private List<Teachers> _teachers;
        private List<Groups> _groups;
        private string _selectedItem1, _selectedItem2, _activity;

        public string Activity
        {
            get => _activity;
            set => SetPropertyChanged(ref _activity, value, nameof(_activity));
        }

        public DateTime Date
        {
            get => _date;
            set => SetPropertyChanged(ref _date, value, nameof(_date));
        }

        public TimeSpan StartTime
        {
            get => _start;
            set => SetPropertyChanged(ref _start, value, nameof(_start));
        }

        public TimeSpan EndTime
        {
            get => _end;
            set => SetPropertyChanged(ref _end, value, nameof(_end));
        }

        public List<Teachers> Teachers
        {
            get => _teachers;
            set => SetPropertyChanged(ref _teachers, value);
        }
        public List<Groups> Groups
        {
            get => _groups;
            set => SetPropertyChanged(ref _groups, value);
        }
        public string SelectedItem1
        {
            get { return _selectedItem1; }
            set { _selectedItem1 = value; OnPropertyChanged(); }
        }
        public string SelectedItem2
        {
            get { return _selectedItem2; }
            set { _selectedItem2 = value; OnPropertyChanged(); }
        }

        public ICommand AddSchedule { get; set; }
        public AddScheduleWindow()
        {
            Date = DateTime.Today;
            AddSchedule = new RelayCommand(o => AddSch());
            using (var context = new KinderGartenDbEntities())
            {
                Teachers = context.Teachers.ToList();
                Groups = context.Groups.ToList();
            }
        }
        private void AddSch()
        {
            try
            {
                using (var context = new KinderGartenDbEntities())
                {
                    TimeSpan startDateTime = new TimeSpan(StartTime.Hours, StartTime.Minutes, StartTime.Seconds);
                    TimeSpan endDateTime = startDateTime.Add(new TimeSpan(0, 40, 0));
                    var selectedItemId1 = int.Parse(SelectedItem1);
                    var selectedItemId2 = int.Parse(SelectedItem2);

                    // проверка на заполнение всех полей
                    if (string.IsNullOrEmpty(Activity) || selectedItemId1 == 0 || selectedItemId2 == 0)
                    {
                        MessageBox.Show("Заполните все поля!");
                        return;
                    }

                    // проверка на конфликты с уже существующими расписаниями
                    var schedules = context.Schedule
                        .Where(s =>
                            s.Date == Date &&
                            ((s.GroupID == selectedItemId1 && s.StartTime <= endDateTime && s.EndTime > startDateTime) ||
                            (s.TeacherID == selectedItemId2 && s.StartTime <= endDateTime && s.EndTime > startDateTime)))
                        .ToList();

                    if (schedules.Any())
                    {
                        foreach (var schedule in schedules)
                        {
                            if (schedule.GroupID == selectedItemId1)
                            {
                                MessageBox.Show("Данная группа уже занята на выбранное время!");
                                return;
                            }

                            if (schedule.TeacherID == selectedItemId2)
                            {
                                MessageBox.Show("Данный преподаватель уже занят на выбранное время!");
                                return;
                            }
                        }
                    }

                    // добавление нового расписания
                    var save = new Schedule
                    {
                        Date = Date,
                        StartTime = startDateTime,
                        EndTime = endDateTime,
                        Activity = Activity,
                        TeacherID = selectedItemId2,
                        GroupID = selectedItemId1
                    };

                    context.Schedule.Add(save);
                    context.SaveChanges();

                    MessageBox.Show("Вы добавили новое расписание!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, повторите попытку!");
            }
        }
    }
}
