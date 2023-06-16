using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kalendar
{

    public class StaticFunc
    {
        static public string StringDateForSQL()
        {
            return $"{(DateTime.Now.Year)}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}.000";
        }
    }



    internal class Date
    {
     public int year;public monthP month;public int day;
     public int hour;public int minute; public int second;
        public TimeDay timeday;

       public  DateTime DT { get; set;}
        public Date(DateTime DT) {
            this.DT = DT;
            year = DT.Year;
 
            month = (monthP)DT.Month-1;
            day = DT.Day;   
            hour = DT.Hour;
            timeday = SerchtimeDay();
            minute = DT.Minute;
            second = DT.Second;
        }

        public TimeDay SerchtimeDay()
        {
            if(hour<4)
                return (TimeDay)0;
            else if(hour<12)
                return (TimeDay)1;
            else if(hour<18) 
                return (TimeDay)2;
            return(TimeDay)3;
        }

        public string ViskosYear() {
            if (DT.Year % 4 == 0)
                return "Високосный";
            return "Не високосный"; 
        } 

        public dayofweek dayWeek()
        {
            return (dayofweek)DT.DayOfWeek;
        }


    }




    public class OrderSpisok
    {
        public List<OrderSForSell> OrderSell { get; set; }

        public OrderSpisok() { 
        Generate();
        }

        

        public void Generate()
        {
           
          
            
        }
    }

    public class Item_for_Sell {
        public List <OrderSForSell> Item_value = new List<OrderSForSell>();
        public Item_for_Sell() {
            for (int i = 0; i < Enum.GetNames(typeof(OrderSForSell)).Length; i++){
                Item_value.Add((OrderSForSell)i);
            }
        }    
    }



    public enum OrderSForSell
    {
        Apple,
        Rasberry,
        Grape,
        Limon
    }




    enum TimeDay
    {
        Ночь,
        Утро,
        День,
        Вечер     
    }



    enum dayofweek {
    Воскресенье,
    Понедельник,
    Вторник,
    Среда,
    Четверг,
    Пятница,
    Суббота,
    }

    enum monthP { 
    Январь,
    Февраль,
    Март,
    Апрель,
    Май,
    Июнь,
    Июль,
    Август,
    Сентябрь,
    Октябрь,
    Ноябрь,
    Декабрь
    }


}
