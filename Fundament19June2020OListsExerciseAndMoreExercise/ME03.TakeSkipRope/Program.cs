using System;
using System.Collections.Generic;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpTxt = Console.ReadLine();
            List<string> inpString = new List<string>();
            List<int> inpNum = new List<int>();
            for (int i = 0; i < inpTxt.Length; i++)
            {
                if (char.IsDigit(inpTxt[i])) inpNum.Add(int.Parse(inpTxt[i].ToString()));
                else inpString.Add(inpTxt[i].ToString());
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < inpNum.Count; i++)
            {
                if (i % 2 == 0) takeList.Add(inpNum[i]);
                else skipList.Add(inpNum[i]);
            }
            
            List<string> resultStr = new List<string>();
            int indexNum = 0;
            //------------------------------------------------------------------
            int countTake = 0;
            while (indexNum < inpString.Count)
            {
                if (indexNum + takeList[countTake] < inpString.Count)
                {
                    resultStr.AddRange(inpString.GetRange(indexNum, takeList[countTake]));
                    indexNum += takeList[countTake] + skipList[countTake++];
                    if (countTake >= takeList.Count) break;
                }
                else
                {
                    resultStr.AddRange(inpString.GetRange(indexNum, inpString.Count - indexNum));
                    break;
                }
            }
            //while(inpString.Count > 0)
            //{
            //    int countTake = 0;
            //    while (countTake < takeList[indexNum])
            //    {
            //        resultStr.Add(inpString[0]);
            //        countTake++;
            //        inpString.RemoveAt(0);
            //        if (inpString.Count <= 0) break;
            //    }
            //    if (inpString.Count <= 0) break;
            //    int countSkip = 0;
            //    while (countSkip < skipList[indexNum])
            //    {
            //        inpString.RemoveAt(0);
            //        if (inpString.Count <= 0) break;
            //        countSkip++;
            //    }
            //    if (inpString.Count <= 0) break;
            //    if (indexNum + 1 < takeList.Count) indexNum++;
            //    else break;
            //}
            Console.WriteLine(string.Join("", resultStr));
        }
    }
}
