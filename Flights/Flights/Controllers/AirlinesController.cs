﻿using BL;
using BL.BLApi;
using BL.BLModels;
using DAL.DalApi;
using DAL.DalModels;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AirlinesController : ControllerBase
    {
        // הכונטרולר פונה לבי_אל והב_אל פונה לדאל לכן מזמנים משתנה מסוג בי _אל ןמזריקים בסיטור משתנה מסוג הבי_אל מנג'ר 
        IBLAirlines airlines;
        public AirlinesController(BLManager bLAirlines)
        {
            airlines = bLAirlines.BLAirlines;
        }
        //מחזירה את רשימת הפרטים של חברות התעופה
        #region Get function 
        [HttpGet]
        public ActionResult<List<BLAirlines>> GetRead()
        {
            List<BLAirlines> al = airlines.BLRead();
            if (al == null) { return NotFound(); }
            return al;
        }
        #endregion

        //מחזירה את רשימת החברות תעופה
        #region Get function
        [HttpGet("names")]
        public ActionResult<List<string>> GetAirlinesName()
        {
            List<string> al = airlines.BLReturnAllTheAirlinesName();
            if (al == null) { return NotFound(); }
            return al;
        }
        #endregion

        #region Post function
        [HttpPost]
        public ActionResult<BLAirlines> AddAirline([FromBody] BLAirlines airline)
        {
            if (airline == null)
            {
                return BadRequest("No data received.");
            }

            var addedAirline = airlines.BLAddAirline(airline); // שומר את חברת התעופה ב-DB
            return CreatedAtAction(nameof(AddAirline), new { id = addedAirline.AirlineId }, addedAirline);
        }
        #endregion

        #region Put function
        [HttpPut]
        public ActionResult<string> ChangeContact(BLAirlines airline)
        {
            if (airline == null) { return null; }
            return airlines.BLChangeContactInfo(airline);
        }
        #endregion

        #region Delete function
        //אין אופציה למחוק
        //[HttpDelete]
        //public ActionResult<BLAirlines> DeleteAirlineById(int id)
        //{
        //    throw RankException(); 
        //}
        #endregion


    }
}
