﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using System;
namespace Implem.Pleasanter.Libraries.Converts
{
    public static class ToControlExtensions
    {
        public static string ToControl(this Enum self, Column column, SiteSettings ss)
        {
            switch (column.TypeName)
            {
                case "int": return self.ToInt().ToString();
                case "bigint": return self.ToLong().ToString();
                default: return self.ToInt().ToString();
            }
        }

        public static string ToControl(this bool self, Column column, SiteSettings ss)
        {
            return self.ToString();
        }

        public static string ToControl(this DateTime self, Column column, SiteSettings ss)
        {
            return column.DisplayControl(self.ToLocal());
        }

        public static string ToControl(this string self, Column column, SiteSettings ss)
        {
            return self;
        }

        public static string ToControl(this int self, Column column, SiteSettings ss)
        {
            return self.ToString(column.StringFormat);
        }

        public static string ToControl(this long self, Column column, SiteSettings ss)
        {
            return self.ToString(column.StringFormat);
        }

        public static string ToControl(this decimal self, Column column, SiteSettings ss)
        {
            return column.ControlType == "Spinner"
                ? column.Display(self, format: false)
                : column.Display(self, ss);
        }
    }
}