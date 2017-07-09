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

namespace ProjectTimeManager.Controllers
{
    public class MemberTimeTrackController : Controller
    {
        private readonly ProjectTimeManagerDbContext db = new ProjectTimeManagerDbContext();

        public ActionResult Index(int id)
        {
            var projectMembers = db.ProjectMember
                .Include(p => p.Person)
                .Include(p => p.Project)
                .Where(p => p.Project_ID == id)
                .ToList();

            List<ProjectMemberStatVM> projectMemberStat = new List<ProjectMemberStatVM>();
            foreach (var member in projectMembers)
            {
                var timeTrackList = db.TimeTrack
                    .Include(p => p.Person)
                    .Include(p => p.Project)
                    .Where(p => p.Project_ID == id)
                    .ToList();

                TimeSpan timeTrack = new TimeSpan();
                foreach (var time in timeTrackList)
                {
                    if (time.Person_ID.Equals(member.Person_ID))
                        timeTrack = timeTrack.Add(time.EndTime - time.StartTime);
                }

                projectMemberStat.Add(new ProjectMemberStatVM
                {
                    FirstName = member.Person.Name,
                    LastName = member.Person.LastName,
                    ProjectName = member.Project.Name,
                    MemberUsedTime = timeTrack
                });
            }

            return View(projectMemberStat);
        }

        // GET: MemberTimeTrack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberTimeTrack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberTimeTrack/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberTimeTrack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberTimeTrack/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberTimeTrack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberTimeTrack/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
