using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class Room_Type_InfoController : Controller
    {
        private OnlineHotelReservationEntities db = new OnlineHotelReservationEntities();

        // GET: /Room_Type_Info/
        public ActionResult Index()
        {
            return View(db.ROOM_TYPE_INFO.ToList());
        }

        // GET: /Room_Type_Info/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TYPE_INFO room_type_info = db.ROOM_TYPE_INFO.Find(id);
            if (room_type_info == null)
            {
                return HttpNotFound();
            }
            return View(room_type_info);
        }

        // GET: /Room_Type_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Room_Type_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ROOM_TYPE,ROOM_PRICE,DESCRIPTION,MAX_GUEST,DISCOUNT")] ROOM_TYPE_INFO room_type_info)
        {
            if (ModelState.IsValid)
            {
                db.ROOM_TYPE_INFO.Add(room_type_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room_type_info);
        }

        // GET: /Room_Type_Info/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TYPE_INFO room_type_info = db.ROOM_TYPE_INFO.Find(id);
            if (room_type_info == null)
            {
                return HttpNotFound();
            }
            return View(room_type_info);
        }

        // POST: /Room_Type_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ROOM_TYPE,ROOM_PRICE,DESCRIPTION,MAX_GUEST,DISCOUNT")] ROOM_TYPE_INFO room_type_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_type_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room_type_info);
        }

        // GET: /Room_Type_Info/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TYPE_INFO room_type_info = db.ROOM_TYPE_INFO.Find(id);
            if (room_type_info == null)
            {
                return HttpNotFound();
            }
            return View(room_type_info);
        }

        // POST: /Room_Type_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ROOM_TYPE_INFO room_type_info = db.ROOM_TYPE_INFO.Find(id);
            db.ROOM_TYPE_INFO.Remove(room_type_info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
