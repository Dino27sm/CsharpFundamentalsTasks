using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FoodData> foodList = new List<FoodData>();
            string pattern = @"(\#|\|)(?<name>[a-zA-Z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calory>\d+)\1";
            string readLine = Console.ReadLine();
            MatchCollection getMatches = Regex.Matches(readLine, pattern);
            if (getMatches.Count > 0)
            {
                for (int i = 0; i < getMatches.Count; i++)
                {
                    string getName = getMatches[i].Groups["name"].Value;
                    string getDate = getMatches[i].Groups["date"].Value;
                    int getCalory = int.Parse(getMatches[i].Groups["calory"].Value);
                    foodList.Add(new FoodData(getName, getDate, getCalory));
                }
            }
            int sumCalory = foodList.Sum(x => x.CaloryValue);
            int daysToLive = sumCalory / 2000;
            Console.WriteLine($"You have food to last you for: {daysToLive} days!");
            foreach (var item in foodList)
            {
                Console.WriteLine($"Item: {item.NameFood}, Best before: {item.DateInfo}, Nutrition: {item.CaloryValue}");
            }
        }
    }
    public class FoodData
    {
        public string NameFood { get; set; }
        public string DateInfo { get; set; }
        public int CaloryValue { get; set; }
        public FoodData(string nameFood, string dateInfo, int caloryValue)
        {
            this.NameFood = nameFood;
            this.DateInfo = dateInfo;
            this.CaloryValue = caloryValue;
        }
    }
}
