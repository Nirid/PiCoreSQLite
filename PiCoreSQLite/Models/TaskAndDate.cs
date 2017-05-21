using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiCoreSQLite.Models
{
    public class TaskAndTime
    {
        public Tasks Task { get; set; }
        public IEnumerable<DateTime> Time { get; set; }
        [Display(Name = "Powtarzanie")]
        public Recurrency TypeOfRecurrency { get; set; }
        [Display(Name = "Zadania tworzone do dnia")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public IEnumerable<DateTime> DaysFromEnum(DateTime Start)
        {
            switch (TypeOfRecurrency)
            {
                case Recurrency.Pojedyncze:
                    yield return Start;
                    yield break;
                case Recurrency.CoDrugiDzien:
                case Recurrency.CoTrzeciDzien:
                case Recurrency.CoCzwartyDzien:
                case Recurrency.CoPiatyDzien:
                case Recurrency.CoSzostyDzien:
                case Recurrency.Tygodniowo:
                case Recurrency.CoTrzydziesciDni:
                case Recurrency.CoDwaTygodnie:
                    while (Start <= EndDate)
                    {
                        yield return Start;
                        Start = Start.AddDays((int)TypeOfRecurrency);
                    }
                    yield break;
                case Recurrency.TenSamDzienMiesiaca:
                    while (Start < EndDate)
                    {
                        yield return Start;
                        Start = Start.AddMonths(1);
                    }
                    yield break;
                case Recurrency.WPoniedzialki:
                case Recurrency.WWtorki:
                case Recurrency.WSrody:
                case Recurrency.WCzwartki:
                case Recurrency.WPiatki:
                case Recurrency.WSoboty:
                case Recurrency.WNiedziele:
                    DayOfWeek dayOfWeek = (DayOfWeek)(((int)TypeOfRecurrency) - 100);
                    if (Start.DayOfWeek > dayOfWeek)
                    {
                        Start = Start.AddDays(dayOfWeek - Start.DayOfWeek);
                    }
                    else if (Start.DayOfWeek < dayOfWeek)
                    {
                        Start = Start.AddDays((7 - (int)Start.DayOfWeek) + (int)dayOfWeek);
                    }
                    while (Start < EndDate)
                    {
                        yield return Start;
                        Start = Start.AddDays(7);
                    }
                    yield break;
            }
        }

        public enum Recurrency
        {
            Pojedyncze,
            [Display(Name = "Co drugi dzień")]
            CoDrugiDzien = 2,
            [Display(Name = "Co trzeci dzień")]
            CoTrzeciDzien = 3,
            [Display(Name = "Co czwarty dzień")]
            CoCzwartyDzien = 4,
            [Display(Name = "Co piąty dzień")]
            CoPiatyDzien = 5,
            [Display(Name = "Co szósty dzień")]
            CoSzostyDzien = 6,
            [Display(Name = "Co tydzień")]
            Tygodniowo = 7,
            [Display(Name = "Co dwa tygodnie")]
            CoDwaTygodnie = 14,
            [Display(Name = "Co trzydzieści dni")]
            CoTrzydziesciDni = 30,
            [Display(Name = "W ten sam dzień miesiąca")]
            TenSamDzienMiesiaca,
            [Display(Name = "W poniedziałki")]
            WPoniedzialki = 101,
            [Display(Name = "W wtroki")]
            WWtorki = 102,
            [Display(Name = "W środy")]
            WSrody = 103,
            [Display(Name = "W czwartki")]
            WCzwartki = 104,
            [Display(Name = "W piątki")]
            WPiatki = 105,
            [Display(Name = "W soboty")]
            WSoboty = 106,
            [Display(Name = "W niedziele")]
            WNiedziele = 100
        }
    }
}
