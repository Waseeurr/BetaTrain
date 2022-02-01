using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class trainer_profileModel : PageModel
    {
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        private readonly IDapperRepository<Linked> _linkedDapperRepository;
        private string TrainerId = "0";
        public trainer_profileModel(IDapperRepository<Trainer> trainerDapperRepository, IDapperRepository<PrivacyUser> userDapperRepository, IDapperRepository<Linked> linkedDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
            _userDapperRepository = userDapperRepository;
            _linkedDapperRepository = linkedDapperRepository;
            //var value = Request.Query["Id"];
        }
        [BindProperty]
        public Trainer Trainer { get; set; }

        [BindProperty]
        public PrivacyUser User { get; set; }

        [BindProperty]
        public List<TraineeList> Trainees { get; set; }
        public void OnGet()
        {
            /*var value = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(value))*/
            TrainerId = Request.Query["Id"];
            if (string.IsNullOrEmpty(TrainerId))
            {
                TrainerId = HttpContext.Session.GetString("UserId");
            }

            if (!string.IsNullOrEmpty(TrainerId))
            {
                string sqlUser = "select * from PrivacyUser where FKId=  " + TrainerId;
                var privacyUser = _userDapperRepository.Query<PrivacyUser>(sqlUser, null)?.FirstOrDefault();
                if (privacyUser != null)
                {
                    User = privacyUser;
                }
                string sql = "select * from Trainer where Id=  " + TrainerId;
                var trainer = _trainerDapperRepository.Query<Trainer>(sql, null)?.FirstOrDefault();
                if (trainer != null)
                {
                    Trainer = trainer;
                }

                string sqlLiked = @"select t.*,l.Status from dbo.Linked l
                                    LEFT JOIN dbo.Trainee t ON l.TraineeId=t.Id 
                                    WHERE status!=-1 and  TrainerId=  " + TrainerId;
                Trainees = _linkedDapperRepository.Query<TraineeList>(sqlLiked, null).ToList();
            }
            /*return Page();*/
        }
        public IActionResult OnPostConnect([FromBody] dynamic dy)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToPage("login_trainee");
            }
            var loginTrainer = HttpContext.Session.GetString("UserId");
            if (HttpContext.Session.GetString("UserType") == "Trainer")
            {
                return new JsonResult(new { Mes = "You can't contact yourself" });
            }
            else
            {
                Linked linked = new Linked();
                linked.TrainerId = Convert.ToInt64((string)dy.Id);
                linked.TraineeId = Convert.ToInt64(loginTrainer);
                linked.Status = 0;
                var linkedId = _linkedDapperRepository.Add(linked);
                if (linkedId > 0)
                {
                    return new JsonResult(new { Mes = "Connect successful" });
                }
                else
                {
                    TempData["Message"] = "Connect failed, please contact the administrator";
                    return Page();
                }
            }
        }
        public IActionResult OnPostAgree([FromBody] dynamic dy)
        {
            //to login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToPage("login_trainee");
            }
            var loginTrainer = HttpContext.Session.GetString("UserId");
            if (HttpContext.Session.GetString("UserType") == "Trainee")
            {
                return new JsonResult(new { Mes = "You can't agree without me" });
            }
            else
            {
                string sql = "update  Linked set status=1 where Status!=-1 and TraineeId=" + (string)dy.Id + " and TrainerId= " + HttpContext.Session.GetString("UserId");
                var linkedId = _linkedDapperRepository.Execute(sql);
                if (linkedId > 0)
                {
                    return new JsonResult(new { Mes = "Agree successful" });
                }
                else
                {
                    TempData["Message"] = "Agree failed, please contact the administrator";
                    return Page();
                }
            }
        }
        public IActionResult OnPostReject([FromBody] dynamic dy)
        {
            //to login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToPage("login_trainee");
            }
            var loginTrainer = HttpContext.Session.GetString("UserId");
            if (HttpContext.Session.GetString("UserType") == "Trainee")
            {
                return new JsonResult(new { Mes = "You can't agree without me" });
            }
            else
            {
                string sql = "update  Linked set status=-1 where TraineeId=" + (string)dy.Id + " and TrainerId= " + HttpContext.Session.GetString("UserId");
                var linkedId = _linkedDapperRepository.Execute(sql);
                if (linkedId > 0)
                {
                    return new JsonResult(new { Mes = "Agree successful" });
                }
                else
                {
                    TempData["Message"] = "Agree failed, please contact the administrator";
                    return Page();
                }
            }
        }
    }
}