using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCafe_v1._5.Models;

namespace MyCafe_v1._5.Controllers
{
    [Authorize(Roles = "Administrator, Manager, Employee")]
    public class Order_DetailController : Controller
    {
        private OrderSystemContainer db = new OrderSystemContainer();

        // GET: Order_Detail
        public ActionResult Index()
        {
            var order_Detail = db.Order_Detail.Include(o => o.Menu).Include(o => o.Order);
            return View(order_Detail.ToList());
        }

        // GET: Order_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id");
            return View();
        }

        // POST: Order_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MenuId,OrderId,GenerateTime,Number")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Order_Detail.Add(order_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", order_Detail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", order_Detail.OrderId);
            return View(order_Detail);
        }

        // GET: Order_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", order_Detail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", order_Detail.OrderId);
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MenuId,OrderId,GenerateTime,Number")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", order_Detail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", order_Detail.OrderId);
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Detail order_Detail = db.Order_Detail.Find(id);
            db.Order_Detail.Remove(order_Detail);
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
