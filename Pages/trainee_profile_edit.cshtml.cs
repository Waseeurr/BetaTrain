using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Common;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class trainee_profile_editModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        public trainee_profile_editModel(IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<PrivacyUser> userDapperRepository, IWebHostEnvironment webHostEnvironment)
        {
            _traineeDapperRepository = traineeDapperRepository;
            _userDapperRepository = userDapperRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Trainee Trainee { get; set; }

        [BindProperty]
        public PrivacyUser User { get; set; }

        [BindProperty]
        public FlieUpload FlieUpload { get; set; }
        public void OnGet()
        {
            var value = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(value))
            {
                string sqlUser = "select * from PrivacyUser where FKId=  " + value;
                var privacyUser = _userDapperRepository.Query<PrivacyUser>(sqlUser, null)?.FirstOrDefault();
                if (privacyUser != null)
                {
                    User = privacyUser;
                }
                string sql = "select * from Trainee where Id=  " + value;
                var trainee = _traineeDapperRepository.Query<Trainee>(sql, null)?.FirstOrDefault();
                if (trainee != null)
                {
                    Trainee = trainee;
                }
            }
        }
        public IActionResult OnPostSave()
        {
            string imageUrl = "";
            if (FlieUpload.FormFile != null)
            {
                imageUrl = Common.UpLoad(FlieUpload.FormFile, _webHostEnvironment.WebRootPath + "/Images");
                Trainee.ImageUrl = imageUrl;
            }
            
            /*string imageUrl = Common.UpLoad(FlieUpload.FormFile, _webHostEnvironment.WebRootPath + "/Images");*/
            string sql = "update PrivacyUser set UserName='" + User.Username + "' where Id= " + User.Id;
            _userDapperRepository.Query<PrivacyUser>(sql);
            Trainee.CreateDateTime = DateTime.Now;
            /*Trainee.ImageUrl = imageUrl;*/
            var traineeId = _traineeDapperRepository.Update(Trainee);
            if (traineeId)
            {
                return RedirectToPage("trainee_profile");
            }
            else
            {
                TempData["Message"] = "save failed, please contact the administrator";
                return Page();
            }
        }
    }
}
