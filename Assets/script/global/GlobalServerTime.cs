using System;
using UnityEngine;
using Susie;

public class GlobalServerTime
{
	
	private static long disToServerTime = 0;

	public static void setServerTime(long time){
		disToServerTime = DateTimeToUnixTimestamp () - time;
		SSDebug.Log("distance to server = " + disToServerTime + " , "+time);
	}                        


	public static long DateTimeToUnixTimestamp()
	{
		// var dateTime = DateTime.Now;
		// var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
		// return Convert.ToInt64((dateTime - start).TotalMilliseconds);
		// return DateTime.Now.Ticks / 10000;

		var Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (long) ((DateTime.UtcNow - Jan1st1970).TotalMilliseconds);
	}

	public static long getServerTime(){
		return DateTimeToUnixTimestamp () - disToServerTime;
	}

	public static long getLastTime(long endTime){
		return endTime - getServerTime();
	}

}

