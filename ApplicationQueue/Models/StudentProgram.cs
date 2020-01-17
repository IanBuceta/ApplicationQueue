using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationQueue.Models
{
    public class StudentProgram
    {
        public StudentProgram(int id, string teamName)
        {
            this.Id = id;
            this.TeamName = teamName;
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Src { get; set; }
        public bool IsRunning {
            get
            {
                return CheckIfRunning();
            }
        }

        private bool CheckIfRunning()
        {
            throw new NotImplementedException();
        }
    }
}
