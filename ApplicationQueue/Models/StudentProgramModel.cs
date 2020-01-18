using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationQueue.Models
{
    public class StudentProgram
    {
        public StudentProgram(uint id, string teamName, string src)
        {
            this.Id = id;
            this.TeamName = teamName;
            this.Src = src;
        }

        public uint Id { get; }
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
            return false;
        }
    }
}
