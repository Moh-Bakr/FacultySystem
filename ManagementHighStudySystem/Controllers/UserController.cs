using ManagementHighStudySystem.Models;
using ManagementHighStudySystem.ViewModel;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ManagementHighStudySystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ViewResult Edit(string id)
        {
            var Data = _context.Users.FirstOrDefault(e => e.Id == id);
            var userData = new UserViewModel
            {
                user = Data,

                Paths = _context.paths.ToList(),


            };
            return View(userData);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            ApplicationUser user = _context.Users.Find(model.user.Id);
            user.path = model.pathid;
            user.Phone = model.user.Phone;
            user.SSN = model.user.SSN;
            user.UserName = model.user.UserName;
            _context.SaveChanges();
            return RedirectToAction("List", "User");
        }
        [Authorize(Roles = "admin")]
        public ViewResult List()
        {
            var status = _context.applicantStatus.ToList();
            var users = _context.Users.ToList();
            List<ApplicationUser> filterdList = new List<ApplicationUser>();
            //filterdList = users;
            bool isIN = false;
            foreach (var item in users.ToList())
            {
                foreach (var state in status)
                {

                    if (item.Id == state.userID)
                    {
                        isIN = true;
                        users.Remove(item);
                        continue;
                    }
                }
                if (isIN)
                {
                    isIN = false;
                    continue;
                }
            }
            var userData = new UserViewModel
            {
                Users = users,
                Paths = _context.paths.ToList(),
            };
            return View(userData);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Accept(string id)
        {
            Status status = new Status();

            status.userID = id;
            status.Condition = "accept";
            _context.applicantStatus.Add(status);
            _context.SaveChanges();
            return RedirectToAction("List", "User");
        }
        [Authorize(Roles = "admin")]
        public ActionResult reject(string id)
        {
            Status status = new Status();

            status.userID = id;
            status.Condition = "reject";
            _context.applicantStatus.Add(status);
            _context.SaveChanges();
            return RedirectToAction("List", "User");
        }

        public ActionResult Dashboard()
        {
            var id = User.Identity.GetUserId();
            ApplicationUser user = _context.Users.Find(id);
            List<ApplicationUser> users = new List<ApplicationUser>();
            users.Add(user);

            var status = _context.applicantStatus.FirstOrDefault(e => e.userID == id);
            string condition;
            if (status == null)
            {
                condition = "underreview";
            }
            else
            {
                condition = status.Condition;
            }
            var userData = new UserViewModel
            {
                Users = users,
                Paths = _context.paths.ToList(),
                StatusValue = condition

            };
            return View(userData);
        }




    }
}