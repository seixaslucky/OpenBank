﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum val)
        {
            return val.GetType()
                  .GetMember(val.ToString())
                  .FirstOrDefault()
                  ?.GetCustomAttribute<DisplayAttribute>(false)
                  ?.Description
                  ?? val.ToString();
        }

        public static string GetEnumDisplayName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Name;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetDisplayShortName(this Enum val)
        {
            return val.GetType()
                      .GetMember(val.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.ShortName
                      ?? val.ToString();
        }

        public static string GetEnumDisplayShortName(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].ShortName;
            }
            else
            {
                return value.ToString();
            }
        }

        public static int GetEnumOrder(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DisplayAttribute[])fi.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Order;
            }
            else
            {
                return -1;
            }
        }
    }
}