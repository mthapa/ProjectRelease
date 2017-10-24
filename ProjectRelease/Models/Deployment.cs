using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectRelease.Models
{
    public class Deployment
    {
        public int DeploymentId { get; set; }
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public Environment Environment {get; set;}
        public string Remarks { get; set; }
                
        public virtual Agency Agency { get; set; }
    }
}