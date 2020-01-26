﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWRSyllabus.Core.Utilities
{
    public static class LINQExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => 
            self?.Select((item, index) => (item, index)) ?? new List<(T, int)>();
    }
}
