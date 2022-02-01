using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;

        public SearchResultsModel(IDapperRepository<Trainer> trainerDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
            

        }

        [BindProperty(SupportsGet = true)]
        public List<Trainers> Trainers { get; set; }

        [BindProperty(SupportsGet = true)]
        public Trainer Trainer { get; set; }


        public void OnGet()
        {
            string sql = "SELECT p.Username,t.* FROM dbo.Trainer t LEFT JOIN dbo.PrivacyUser p ON t.Id=p.FKId WHERE 1=1 AND p.UserType='Trainer' ";

            Trainers = _trainerDapperRepository.Query<Trainers>(sql, null).ToList();
        }

        public IActionResult OnPostSeach([FromBody] dynamic my)
        {
            string sql = "SELECT p.Username,t.* FROM dbo.Trainer t LEFT JOIN dbo.PrivacyUser p ON t.Id=p.FKId WHERE 1=1 AND p.UserType='Trainer' ";
            if (!string.IsNullOrEmpty((string)my.KindOfTrainer))
            {
                sql += " and KindOfTrainer like '%" + (string)my.KindOfTrainer + "%'";
            }
            if (!string.IsNullOrEmpty((string)my.Gender))
            {
                sql += " and Gender ='" + (string)my.Gender + "'";
            }
            if (!string.IsNullOrEmpty((string)my.TeachingType))
            {
                sql += " and TeachingType ='" + (string)my.TeachingType + "'";
            }
            Trainers = _trainerDapperRepository.Query<Trainers>(sql, null).ToList();
            return new JsonResult(Trainers);
        }
    }
}
