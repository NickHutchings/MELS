﻿using System;
using System.Xml;

public class timeClass
{
    private int day;
    private int month;
    private int year;
    string parens;
    private int[] tabDaysPerMonth;
    public timeClass()
	{
        tabDaysPerMonth = new int[12];

        tabDaysPerMonth[0] = 31;
        tabDaysPerMonth[1] = 28;
        tabDaysPerMonth[2] = 31;
        tabDaysPerMonth[3] = 30;
        tabDaysPerMonth[4] = 31;
        tabDaysPerMonth[5] = 30;
        tabDaysPerMonth[6] = 31;
        tabDaysPerMonth[7] = 31;
        tabDaysPerMonth[8] = 30;
        tabDaysPerMonth[9] = 31;
        tabDaysPerMonth[10] = 30;
        tabDaysPerMonth[11] = 31;
	}
    public timeClass(timeClass previousclass)
    {
        day = previousclass.day;
        month = previousclass.month;
        year = previousclass.year;
        tabDaysPerMonth = new int [12];
        for (int i = 0; i < 12; i++)
            tabDaysPerMonth[i] = previousclass.tabDaysPerMonth[i];
    }
    public bool setDate(int aday, int amonth, int ayear)
    {
        bool isOk = true;
        if ((aday <= 0) || (aday > 31))
            isOk = false;
        else
            day = aday;
        if ((amonth <= 0) || (amonth > 12))
            isOk = false;
        else
            month = amonth;
        year= ayear;
        return isOk;
    }
    public long getLongTime()
    {
        long longTime = 365*(year-1);  // no leap years here!
        for (int i = 0; i < month-1; i++)
        {
            longTime += tabDaysPerMonth[i];
        }
        longTime += day;
        return longTime;
    }
    public int getJulianDay()
    {
        int JulianDay = 0;
        for (int i = 0; i < month - 1; i++)
        {
            JulianDay += tabDaysPerMonth[i];
        }
        JulianDay += day;
        return JulianDay;
    }

    public int GetYear() { return year; }
    public int GetRunningMonth()
    {
        int retVal = year * 12 + month;
        if (day > 15)
            retVal += 1;
        return retVal;
    }
    public int GetDay() { return day; }
    public int GetMonth() { return month; }
    public void SetYear(int aVal) { 
        year = aVal; 
    }
    public void incrementOneDay()
    {
        if (day + 1 > tabDaysPerMonth[month-1])
        {
            day = 1;
            month++;
        }
        else
            day++;
        if (month > 12)
        {
            year++;
            month = 1;
        }
    }

    public int GetDaysInMonth(int amonth)
    {
        return tabDaysPerMonth[amonth-1];
    }

    public void Write()
    {
        GlobalVars.Instance.writeInformationToFiles("day", "Day", "-", day, parens);
        GlobalVars.Instance.writeInformationToFiles("month", "Month", "-", month, parens);
        GlobalVars.Instance.writeInformationToFiles("year", "Year", "-", year, parens);
    }
    public string ToString()
    {
        return "day " + day.ToString() + " month " + month.ToString() + " year " + year.ToString(); 
    }
}
