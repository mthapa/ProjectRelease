using ProjectRelease.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectRelease
{
    public class ProjectReleaseContext : DbContext
    {
        public DbSet<Deployment> Deployments { get; set; }
        public DbSet<Agency> Agencies { get; set; }

    }
}