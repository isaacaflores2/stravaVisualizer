﻿using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Models.MonthSummary
{
    public class MonthSummary
    {
        public int Month { get; set; }
        public DateTime WeekStartDate { get; set; }
        public ICollection<VisualActivity> Activites { get; set; }


        public MonthSummary(DateTime today, IList<VisualActivity> visualActivities)
        {
            Month = today.Month;
            WeekStartDate = getCurrentWeekStartDate(today);
            Activites = getActivitiesForThisMonth(visualActivities);
        }

        public int getCurrentMonth()
        {
            return Month;
        }

        public static DateTime getCurrentWeekStartDate(DateTime today)
        {
            var todayDay = today.Day;
            //var dayOfWeek = (int)today.DayOfWeek;
            var dayOfWeek = today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)today.DayOfWeek;

            var date = todayDay - (dayOfWeek - 1);
            return new DateTime(today.Year, today.Month, date);
        }

        public IList<VisualActivity> getActivitiesForThisMonth(ICollection<VisualActivity> visualActivities)
        {
            var activites = (from activity in visualActivities
                         where activity.Summary.StartDate.Value.Month == Month &&
                         activity.Summary.StartDate.Value.Year == WeekStartDate.Year
                         select activity).ToList();

            return activites;
        }

        public IList<VisualActivity> getActivitiesForThisWeek(ICollection<VisualActivity> visualActivities)
        {
            //if ((activity.Summary.StartDate.Value.Date.Day >= Model.WeekStartDate.Day) && (activity.Summary.StartDate.Value.Date.Day <= Model.WeekStartDate.Day + 6))

            var activites = (from activity in visualActivities
                             where (activity.Summary.StartDate.Value.Date.Day >= WeekStartDate.Day) && 
                             (activity.Summary.StartDate.Value.Date.Day <= WeekStartDate.Day + 6)
                             select activity).ToList();

            return activites;
        }
    }
}