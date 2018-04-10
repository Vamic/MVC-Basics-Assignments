using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public static class TemperatureChecker
    {
        public enum Status
        {
            Normal,
            Fever,
            Hypothermia
        }
        public static Status CheckTemperature(int temp)
        {
            if (temp < 35) return Status.Hypothermia;
            if (temp > 38) return Status.Fever;
            return Status.Normal;
        }
    }
}