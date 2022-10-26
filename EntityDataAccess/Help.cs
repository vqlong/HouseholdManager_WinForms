using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityDataAccess
{
    public class Help
    {

    }

    public static class Extension
    {
        /// <summary>
        /// Chuyển chuỗi ngày tháng dạng dd/MM/yyyy thành kiểu DateTime.
        /// </summary>
        /// <param name="textDate"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string textDate)
        {
            var match = Regex.Match(textDate, @"^(?<Day>\d{2})\/(?<Month>\d{2})\/(?<Year>\d{4})$");

            if (match != null && match.Value != "")
                return new DateTime(int.Parse(match.Groups["Year"].ToString()), int.Parse(match.Groups["Month"].ToString()), int.Parse(match.Groups["Day"].ToString()));

            return null;
        }
    }
}
