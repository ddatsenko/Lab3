using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    struct MyTime
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }
        public override string ToString()
        {
            return string.Format(hour + ":" + minute.ToString("00") + ":" + second.ToString("00"));
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the time in 24-hr format inserting colon after hours and minutes (e.g. hh:mm:ss):");
            string[] temp = Console.ReadLine().Split(':');
            int h = Convert.ToInt32(temp[0]);
            int m = Convert.ToInt32(temp[1]);
            int s = Convert.ToInt32(temp[2]);
            MyTime t = new MyTime(h, m, s);
            Console.WriteLine("");
            Console.WriteLine("Seconds elapsed since midnight (00:00:00):");
            Console.WriteLine(TimeSinceMidnight(t));

            Console.WriteLine("");

            Console.WriteLine("Add one hour:  {0}", AddOneHour(ref t));
            Console.WriteLine("Add one minute:  {0}", AddOneMinute(ref t));
            Console.WriteLine("Add one second:  {0}", AddOneSecond(ref t));

            Console.WriteLine("");

            Console.WriteLine("Enter the number of seconds you want to add:");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine(AddSeconds(t, seconds));


            Console.WriteLine("");

            Console.WriteLine("Enter the number of seconds that have passed since midnight to know the exact time:");
            int SecondFromTheStart = int.Parse(Console.ReadLine());
            Console.WriteLine(TimeSinceMidnight(SecondFromTheStart));

            Console.WriteLine("");

            Console.WriteLine("To determine the difference between two points of time enter the first point of time in 24-hr format inserting colon after hours and minutes (e.g. hh:mm:ss):");
            string[] temp1 = Console.ReadLine().Split(':');
            int h1 = Convert.ToInt32(temp1[0]);
            int m1 = Convert.ToInt32(temp1[1]);
            int s1 = Convert.ToInt32(temp1[2]);
            MyTime mt1 = new MyTime(h1, m1, s1);
            Console.WriteLine("");
            Console.WriteLine("Enter the second point of time in 24-hr format inserting colon after hours and minutes (e.g. hh:mm:ss):");
            string[] temp2 = Console.ReadLine().Split(':');
            int h2 = Convert.ToInt32(temp2[0]);
            int m2 = Convert.ToInt32(temp2[1]);
            int s2 = Convert.ToInt32(temp2[2]);
            MyTime mt2 = new MyTime(h2, m2, s2);
            Console.WriteLine("");
            Console.WriteLine("The difference between these two points of time in seconds is:");
            Console.WriteLine(Difference(mt1, mt2));

            Console.WriteLine("");
            Console.WriteLine("Enter the time in 24-hr format inserting colon after hours and minutes to find out which class it is right now (e.g. hh:mm:ss):");
            string[] temp3 = Console.ReadLine().Split(':');
            int h3 = Convert.ToInt32(temp3[0]);
            int m3 = Convert.ToInt32(temp3[1]);
            int s3 = Convert.ToInt32(temp3[2]);
            Console.WriteLine("");
            Console.WriteLine(WhatLesson(new MyTime(h3, m3, s3)));

            Console.ReadKey();
        }
        static int TimeSinceMidnight(MyTime t)
        {
            int sec = (((t.second + t.minute * 60 + t.hour * 3600) % 86400) + 86400) % 86400;
            return sec;
        }
        static MyTime TimeSinceMidnight(int t)
        {
            t = ((t % 86400) + 86400) % 86400;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }
        static MyTime AddOneMinute(ref MyTime t)
        {
            int temp = (((t.second + (t.minute + 1) * 60 + t.hour * 3600) % 86400) + 86400) % 86400;
            t.hour = temp / 3600;
            t.minute = (temp / 60) % 60;
            t.second = temp % 60;
            return t;
        }
        static MyTime AddOneHour(ref MyTime t)
        {
            int temp = (((t.second + t.minute * 60 + (t.hour + 1) * 3600) % 86400) + 86400) % 86400;
            t.hour = temp / 3600;
            t.minute = (temp / 60) % 60;
            t.second = temp % 60;
            return t;
        }
        static MyTime AddOneSecond(ref MyTime t)
        {
            int temp = (((t.second + 1 + t.minute * 60 + t.hour * 3600) % 86400) + 86400) % 86400;
            t.hour = temp / 3600;
            t.minute = (temp / 60) % 60;
            t.second = temp % 60;
            return t;
        }
        static MyTime AddSeconds(MyTime t, int s)
        {
            int temp = (((t.second + s + t.minute * 60 + t.hour * 3600) % 86400) + 86400) % 86400;
            t.hour = temp / 3600;
            t.minute = (temp / 60) % 60;
            t.second = temp % 60;
            return t;
        }
        static int Difference(MyTime mt1, MyTime mt2)
        {
            return (TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2));
        }
        static string WhatLesson(MyTime mt)
        {
            int seconds = TimeSinceMidnight(mt);
            if (seconds > 0 && seconds < 28800) return "Classes haven't started yet";
            else if (seconds >= 28800 && seconds < 33600) return "1st class";
            else if (seconds >= 33600 && seconds < 34800) return "Recess after 1st class";
            else if (seconds >= 34800 && seconds < 39600) return "2nd class";
            else if (seconds >= 39600 && seconds < 40800) return "Recess after 2nd class";
            else if (seconds >= 40800 && seconds < 45600) return "3rd class";
            else if (seconds >= 45600 && seconds < 46800) return "Recess after 3rd class";
            else if (seconds >= 46800 && seconds < 51600) return "4th class";
            else if (seconds >= 51600 && seconds < 52800) return "Recess after 4th class";
            else if (seconds >= 52800 && seconds < 57600) return "5th class";
            else if (seconds >= 57600 && seconds < 58200) return "Recess after 5th class";
            else if (seconds >= 58200 && seconds < 63000) return "6th class";
            else if (seconds >= 63000 && seconds < 86400) return "Classes have ended";
            else return "Error: you have entered the wrong value";
        }
        
    }
}