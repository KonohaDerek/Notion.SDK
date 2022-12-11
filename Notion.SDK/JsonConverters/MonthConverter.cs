﻿using System.Collections.Generic;

namespace Notion.SDK.JsonConverters
{
    public class MonthConverter
    {
        internal static Dictionary<int, string> Maps = new() {
            {1, "一月" },
            {2, "二月" },
            {3, "三月" },
            {4, "四月" },
            {5, "五月" },
            {6, "六月" },
            {7, "七月" },
            {8, "八月" },
            {9, "九月" },
            {10, "十月" },
            {11, "十一月" },
            {12, "十二月" },
        };

        public static string ToString(int Month) { return Maps[Month]; }
    }
}
