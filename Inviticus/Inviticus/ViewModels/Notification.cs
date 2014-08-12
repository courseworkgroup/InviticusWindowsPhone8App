using Inviticus.Model;
using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inviticus.ViewModels
{
    class Notifications
    {
        SharedInformation info = SharedInformation.getInstance();
        private BabyViewModel _babyViewModel;
        public bool removeFromSchedule { get; set; }

        public void SetNotification()
        {
            _babyViewModel = new BabyViewModel(info.babyID);
            //DateTime dTime = new DateTime();

            foreach(ImmunisationData vaccine in _babyViewModel.ImmunisationData)
            {
                TimeSpan duration = new TimeSpan();
                duration =  Convert.ToDateTime(vaccine.Date).Subtract(DateTime.Now);
                int x = Convert.ToInt32(duration);

                
                if(DateTime.Now < Convert.ToDateTime(vaccine.Date))
                {
                    removeFromSchedule = true;
                    break;
                }

                string reminderName = _babyViewModel.Baby.Name + " Vaccination Reminder";
                string notificationMessage;

                if (!removeFromSchedule)
                {

                    var reminder = new Reminder(reminderName);
                    reminder.Title = reminderName;
                    reminder.BeginTime = Convert.ToDateTime(vaccine.Date);
                    reminder.ExpirationTime = Convert.ToDateTime(vaccine.Date).AddDays(2);
                    reminder.RecurrenceType = RecurrenceInterval.Daily;
                    switch (x)
                    {
                        case 0:
                            notificationMessage = string.Format("Polio 0 and BCG vaccine");
                            break;
                        case 42://6weeks
                            notificationMessage = string.Format("Polio 1 and DPT-HepB +Hib 1 vaccine");
                            break;
                        case 70: //10weeks
                            notificationMessage = string.Format("Polio 2 and DPT-HebB+Hib2 vaccine");
                            break;
                        case 98: //14weeks
                            notificationMessage = string.Format("Polio 3 and DPT-HebB+Hib3 vaccine");
                            break;
                        case 273://9months
                            notificationMessage = string.Format("Measles vaccine");
                            break;
                        default:
                            notificationMessage = string.Format("Vaccination done");
                            break;
                    }

                    reminder.Content = notificationMessage;

                    // reminder.NavigationUri = new Uri(string.Format("/ClientDetailsPage.xaml?selectedItem={0}", item.Id), UriKind.Relative);
                    try
                    {
                        if (ScheduledActionService.Find(reminderName) != null)
                        {
                            ScheduledActionService.Remove(reminderName);
                        }

                        ScheduledActionService.Add(reminder);
                     }
                     catch (InvalidOperationException ex)
                     {
                        MessageBox.Show(reminderName + " Error: " + ex.Message);
                     }
                }
                else
                {
                    try
                    {
                        ScheduledActionService.Remove(reminderName);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(reminderName + " Error: " + ex.Message);
                    }
                }
                    
            }                   

           // bool removeFromSchedule = DateTime.Now.Subtract(dTime).Days >= 0);

            //string reminderName = _babyViewModel.Baby.Name + " reminder";
            //string notificationMessage;
          
        }
    }
}
