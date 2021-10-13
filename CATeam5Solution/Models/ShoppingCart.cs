using System;
using System.Collections.Generic;
using CATeam5Solution.Models;

namespace CATeam5Solution.Models
{
    public class ShoppingCart
    {
        public static List<Dictionary<string, int>> ProductList = new List<Dictionary<string, int>>();
        Dictionary<string, int> ShoppingCartDict = new Dictionary<string, int>();
    }
}
