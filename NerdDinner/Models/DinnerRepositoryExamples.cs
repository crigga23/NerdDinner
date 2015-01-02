using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class DinnerRepositoryExamples
    {
        private DinnerRepository dinnerRepository = new DinnerRepository();

        public Dinner GetDinner()
        {
            Dinner dinner = dinnerRepository.GetDinner(3);
            return dinner;
        }

        public IQueryable<Dinner> FindAndPrintUpcomingDinners()
        {
            var upcomingDinners = dinnerRepository.FindUpcomingDinners();

            foreach (var dinner in upcomingDinners)
            {
                Debug.Write(dinner);
            }

            return upcomingDinners;
        }



    }
}