using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrossCountryApp.Models;

    public class dbContextParticipantData : DbContext
    {
        public dbContextParticipantData (DbContextOptions<dbContextParticipantData> options)
            : base(options)
        {
        }

        public DbSet<CrossCountryApp.Models.Participant> Participant { get; set; }

        public DbSet<CrossCountryApp.Models.Houses> Houses { get; set; }

}
