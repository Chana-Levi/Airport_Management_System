
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IAirlines
    {
        //פונקציה שמקבלת חברה ומדפיסה את כול הטיסות(לעשות את זה 
        //מחזירה את רשימת הפרטים של חברות התעופה
        public List<Airline> Read();
        //פונקציה שמחזירה את רשימת שמות חברות תעופה
        public List<Airline> ReturnAllTheAirlinesName();
        //פונקציה שמוסיפה חברת תעופה
        public Airline AddAirline(Airline airline);
        //פונקציה שמעדכנת את פרטי יצירת הקשר
        public string ChangeContactInfo(Airline airline);
        //מחיקת חברה תעופה
        public Airline DeleteAirline(int id);


    }
}
