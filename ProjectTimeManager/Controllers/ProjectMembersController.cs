using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTimeManager.DAL;
using ProjectTimeManager.Model;
using ProjectTimeManager.Models;
using ProjectTimeManager.DAL.Repository;

namespace ProjectTimeManager.Controllers
{
    public class ProjectMembersController : Controller
    {
        private readonly ProjectMemberRepository ProjectMemberDb = new ProjectMemberRepository();
        private readonly PersonRepository PersonDb = new PersonRepository();
        private readonly ProjectRepository ProjectDb = new ProjectRepository();

        // GET: ProjectMembers
        public ActionResult Index()
        {
            return View(ProjectMemberDb.GetList());
        }

        // GET: ProjectMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = ProjectMemberDb.Find(id.Value);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            return View(projectMember);
        }

        // GET: ProjectMembers/Create
        public ActionResult Create()
        {
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name");
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name");
            return View();
        }

        // POST: ProjectMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Project_ID,Person_ID")] ProjectMember projectMember)
        {
            if (ModelState.IsValid)
            {
                ProjectMemberDb.Add(projectMember);
                return RedirectToAction("Index");
            }

            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // GET: ProjectMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = ProjectMemberDb.Find(id.Value);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // POST: ProjectMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Project_ID,Person_ID")] ProjectMember projectMember)
        {
            bool isOk = TryUpdateModel(projectMember);
            if (ModelState.IsValid && isOk)
            {
                ProjectMemberDb.Update(projectMember);
                return RedirectToAction("Index");
            }
            ViewBag.Person_ID = new SelectList(PersonDb.GetList(), "ID", "Name", projectMember.Person_ID);
            ViewBag.Project_ID = new SelectList(ProjectDb.GetList(), "ID", "Name", projectMember.Project_ID);
            return View(projectMember);
        }

        // GET: ProjectMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMember projectMember = ProjectMemberDb.Find(id.Value);
            if (projectMember == null)
            {
                return HttpNotFound();
            }
            return View(projectMember);
        }

        // POST: ProjectMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectMember projectMember = ProjectMemberDb.Find(id);
            bool ok = ProjectMemberDb.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ProjectMemberDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
